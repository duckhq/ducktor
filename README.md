# Duck Debugger UI

A debugger UI that can be used to test different aspects of Duck, which might be hard to replicate against a real CI server.

## Prerequisites

* .NET Core SDK 3.1

## Running

### 1. Start the debugger UI:

```
> cd src
> dotnet run --project debugger
```

### 2. Point a Duck debug collector to the debugger in Duck's configuration:

```json
{
    "collectors": [
        {
            "debugger": {
                "id": "debug",
                "serverUrl": "http://localhost:5000"
            }
        }
    ]
}
```

### 3. Navigate to the Debugger UI

* [http://localhost:5000](http://localhost:5000)