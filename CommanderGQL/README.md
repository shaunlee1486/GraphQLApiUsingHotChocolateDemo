https://localhost:7036/graphql/
https://localhost:7036/graphql-voyager

AddPooledDbContextFactory
```
query {
	a: platform {
		id
		name
	}
	b: platform {
		id
		name
	}
	c: platform {
		id
		name
	}
}
```
```
query {
  platform {
    id
    name
    commands {
      id
      howTo
      commandLine
    }
  }
}
```
```
query {
	command(where: {platformId: {eq: 1}}) {
		id
		platform {
			name
			id
		}
		commandLine
		howto
	}
}

{
  "data": {
    "command": [
      {
        "id": 1,
        "platform": {
          "name": ".net",
          "id": 1
        },
        "commandLine": "dotnet build ",
        "howTo": "build a project"
      },
      {
        "id": 2,
        "platform": {
          "name": ".net",
          "id": 1
        },
        "commandLine": "dotnet run",
        "howTo": "run a project"
      }
    ]
  }
}
```
```
query {
  platform(order: {name: DESC}) {
    id
    name
  }
}

{
  "data": {
    "platform": [
      {
        "id": 2,
        "name": "nodejs"
      },
      {
        "id": 3,
        "name": "java"
      },
      {
        "id": 1,
        "name": ".net"
      }
    ]
  }
}
```

```
mutation {
  addPlatform(input: {
    name: "ubuntu"
  }) {
    platform {
      id
      name
    }
  }
}
```
```
mutation {
  addCommand(input: {
    howTo: "perform diction listening"
    commandLine: "ls"
    platformId: 4
  }) {
    command {
      id
      howTo
      commandLine
      platform {
        id
        name
      }
    }

  }
}

{
  "data": {
    "addCommand": {
      "command": {
        "id": 5,
        "howTo": "perform diction listening",
        "commandLine": "ls",
        "platform": {
          "id": 3,
          "name": "java"
        }
      }
    }
  }
}


```

```
subscription {
  onPlatformAdded {
    id
    name
  }
}
```