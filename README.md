# Ducktor

A debugger that can be used to test different aspects of Duck, which might be hard to replicate against a real CI server.

## Prerequisites

* .NET Core SDK 3.1

## Running

### 1. Start Ducktor:

To build and run Ducktor:

```
> cd src
> dotnet run --project Ducktor
```

Or, you can run Ducktor in a Docker container:

```
> docker run --rm -p 5000:80 duckhq/ducktor:latest
```

### 2. Point a Duck debug collector to Ducktor in Duck's configuration:

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

### 3. Navigate to the Ducktor UI

* [http://localhost:5000](http://localhost:5000)