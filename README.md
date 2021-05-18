# DefaultUnDo
DefaultUnDo is a simple [Command pattern](https://en.wikipedia.org/wiki/Command_pattern) implementation to ease the addition of an undo/redo feature.

[![NuGet](https://buildstats.info/nuget/DefaultUnDo)](https://www.nuget.org/packages/DefaultUnDo)
[![Coverage Status](https://coveralls.io/repos/github/Doraku/DefaultUnDo/badge.svg?branch=master)](https://coveralls.io/github/Doraku/DefaultUnDo?branch=master)
![continuous integration status](https://github.com/doraku/defaultundo/workflows/continuous%20integration/badge.svg)
[![preview package](https://img.shields.io/badge/preview-package-blue?style=flat&logo=github)](https://github.com/Doraku/DefaultUnDo/packages/26448)

- [Api documentation](./documentation/api/DefaultUnDo.md 'Api documentation')
<a/>

- [Requirement](#Requirement)
- [Overview](#Overview)

<a name='Requirement'></a>
# Requirement
Compatible from .NETStandard 1.0.  
For development, a C#8.0 compatible environment, net framework 4.8, net core 1.0 and netcore 3.0 are required to build and run all tests (it is possible to disable some target in the test project if needed).

<a name='Overview'></a>
# Overview
Easy to use, just instanciate a `UnDoManager` and get going. Numerous extension methods are available to ease the integration.
```csharp
IUnDoManager manager = new UnDoManager();

// do an action and record it in the manager, undoAction being the undo equivalent of the action
manager.Do(doAction, undoAction);

if (manager.CanUndo)
{
    manager.Undo();
}

if (Manager.CanRedo)
{
    manager.Redo();
}

// clean any recorded action
manager.Clear();
```

Example of how to set a value
```csharp
IUnDoManager manager = new UnDoManager();

int field = 42;

manager.Do(v => field = v, 1337, field);

// In mvvm we all have some kind of base type
public abstract class ANotifyPropertyChanged : INotifyPropertyChanged
{
    private sealed class UnDoProperty<T> : UnDoField<T>
    {
        private readonly ANotifyPropertyChanged _parent;
        private readonly string _propertyName;

        public UnDoProperty(ANotifyPropertyChanged parent, IUnDoManager unDoManager, string propertyName)
            : base(unDoManager, _ => $"Changed {typeof(T).GetFriendlyShortName()} {propertyName}")
        {
            _parent = parent;
            _propertyName = propertyName;
        }

        // to call PropertyChanged when changing value
        protected override void PostSet(T value) => _parent.NotifyPropertyChanged(_propertyName);
    }

    protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
        if ((field is IEquatable<T> equatable && equatable.Equals(value))
            || (typeof(T).IsValueType && Equals(field, value))
            || ReferenceEquals(field, value))
        {
            return false;
        }

        field = value;

        NotifyPropertyChanged(propertyName);

        return true;
    }

    // need to pass the unDoManager in case the UnDoField is not initialised, this is mainly to keep the same signature between normal field and UnDoField (ref field, value)
    // but you can ommit the IUnDoManager and ref if you choose to initialize UnDoField in the constructor
    protected bool SetProperty<T>(IUnDoManager unDoManager, ref UnDoField<T> field, T value, [CallerMemberName] string propertyName = null)
    {
        field ??= new UnDoProperty<T>(this, unDoManager, propertyName);
        T oldValue = field;

        if ((oldValue is IEquatable<T> equatable && equatable.Equals(value))
            || (typeof(T).IsValueType && Equals(oldValue, value))
            || ReferenceEquals(oldValue, value))
        {
            return false;
        }

        field.Value = value;

        return true;
    }

    public event PropertyChangedEventHandler PropertyChanged;
}

// usage in derrived types
private UnDoField<string> _field;

public string Field
{
    get => _field;
    set => SetProperty(manager, ref _field, value);
}

// events interraction
manager.Do(
    () => PropertyChanged += OnPropertyChanged,  // executed on Do/Redo
    () => PropertyChanged -= OnPropertyChanged); // executed on Undo

// Need something to only happen in Do/Redo
manager.DoOnDo(() => NotifyPropertyChanged(nameof(MyProperty)));

// Or only on Undo
manager.DoOnUndo(() => NotifyPropertyChanged(nameof(MyProperty)));
```

`ICollection<T>`, `IList<T>`, `IDictionary<TKey, TValue>` and `ISet<T>` can be coverterted to an undo instance so that any action performed on them will generate a `IUnDo` action on the manager.
```csharp
IUnDoManager manager = new UnDoManager();

// use myList as you would use your list normaly
IList<int> myList = new List<int>().AsUnDo(manager);

// use myCollection as you would use your collection normaly
// note than the returned collection also implement INotifyCollectionChanged
ICollection<int> myCollection = new ObservableCollection<int>().AsUnDo(manager);

// use myDictionary as you would use your dictionary normaly
IDictionary<int, string> myDictionary = new Dictionary<int, string>().AsUnDo(manager);

// use mySet as you would use your set normaly
ISet<int> mySet = new HashSet<int>().AsUnDo(manager);
```

To generate a custom description when changes occure on those undo collection, the `AsUnDo` extension method can take a `Func<UnDoCollectionOperation, object> descriptionFactory` parameter.

It is possible to declare a transaction scope for your operations so a single undo/redo will execute all the contained operations.
```csharp
IUnDoManager manager = new UnDoManager();

using (IUnDoTransaction transaction = manager.BeginTransaction())
{
    manager.Do(action1, undo1);
    manager.Do(action2, undo2);

    // if you do not commit the transaction, all operations inside the scope will be undone on transaction dispose
    transaction.Commit();
}

// both undo2 and undo1 will be called in this order
manager.Undo();

// both action1 and action2 will be called in this order
manager.Redo();
```

If a group scope is declared inside an other group scope, all operations will be grouped in the same undo/redo operation.
```csharp
IUnDoManager manager = new UnDoManager();

using (IUnDoTransaction transaction1 = manager.BeginTransaction())
{
    manager.Do(action1, undo1);

    using (IUnDoTransaction transaction2 = manager.BeginTransaction())
    {
        manager.Do(action2, undo2);

        transaction2.Commit();
    }

    transaction1.Commit();
}

// both undo2 and undo1 will be called in this order
manager.Undo();

// both action1 and action2 will be called in this order
manager.Redo();
```

`IUnDoManager.Undo` and `IUnDoManager.Redo` calls are not supported when inside a transaction.

To keep track of the modification, a `Version` property is available on the manager.

Missing something? you can easily extend what you need by creating your own implementations of the `IUnDo` interface and extension methods to ease the usage. Feel free to open an issue or send a pull request.