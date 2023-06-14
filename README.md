	
## Simple Service Locator (C#)

Simple Service Locator is a very simple ServiceLocator implementation. It serves as an easy alternative to Dependency Injection for small or legacy projects. 

---

## Usage

### Basic Setup

```csharp
using GHSoftware;

// Initialize the ServiceLocator
var serviceLocator = ServiceLocator.Default;

// Set a service
serviceLocator.Set<IService>(new ServiceImplementation());
```

### Accessing a Service

After you have set up the services you can access them using the `Get<T>()` method. Here's an example:

```csharp
// Retrieve a service
var service = serviceLocator.Get<IService>();
```

### Using the Lazy Service Instantiation

If you want to delay the instantiation of your service until it's actually needed, you can use the `GetLazy<T>()` method. This method returns a `Lazy<T>` object, which will only create the instance when it's accessed for the first time.

```csharp
// Retrieve a lazily instantiated service
var lazyService = serviceLocator.GetLazy<IService>();

// Use the service
var service = lazyService.Value;
```

---

## Examples

### Using the ServiceLocator with Multiple Services

```csharp
using GHSoftware;

// Initialize the ServiceLocator
var serviceLocator = ServiceLocator.Default;

// Set multiple services
serviceLocator.Set<IService1>(new Service1Implementation());
serviceLocator.Set<IService2>(new Service2Implementation());
serviceLocator.Set<IService3>(new Service3Implementation());

// Retrieve the services
var service1 = serviceLocator.Get<IService1>();
var service2 = serviceLocator.Get<IService2>();
var service3 = serviceLocator.Get<IService3>();
```

### Handling Exceptions

If a service is not available, the `Get<T>()` method throws a `NotImplementedException`. Here's how you can handle it:

```csharp
try
{
    var service = serviceLocator.Get<IService>();
}
catch (NotImplementedException ex)
{
    Console.WriteLine(ex.Message);
}
```

---

## License

This project is licensed under the MIT License.

---

Please, feel free to contribute or report any issues.