# Function Requirements

## Objective
Write a function with the signature `public int solution(string[] Connections, string Name1, string Name2)` that takes three parameters. The function aims to determine the shortest relationship path between two people, `Name1` and `Name2`, based on an array of string connections, `Connections`. Each string in `Connections` represents a direct relationship between two people, separated by a colon. The function should return an integer value representing the number of intermediary connections between `Name1` and `Name2`.

## Parameters
- `Connections`: An array of strings where each string represents a relationship between two people in the format "Person1:Person2".
- `Name1`: The name of the first person.
- `Name2`: The name of the second person.

## Return Value
- **-1**: If there is no relationship between `Name1` and `Name2`.
- **Count**: An integer representing the number of intermediary connections between `Name1` and `Name2`.

## Rules
1. The function should be case-sensitive.
2. The function should handle cycles in relationships gracefully.
3. If there are multiple paths between `Name1` and `Name2`, return the shortest path.

## Examples
- `Connections = ["Martin:Job","Kim:Job","Martin:David","Kim:Larsey","Larsey:Job"], Name1 = "Martin", Name2 = "Job"` should return 1 (Martin -> Job)
- `Connections = ["Martin:Job","Kim:Job","Kim:David","Kim:Larsey","Larsey:Job", "Larsey:David"], Name1 = "Martin", Name2 = "David"` should return 2 (Martin -> Kim -> David)

## Test Cases

### Valid Test Cases
1. `Connections = ["Martin:Job","Kim:Job","Martin:David","Kim:Larsey","Larsey:Job"], Name1 = "Martin", Name2 = "Job"` should return 1
1. `Connections = ["Martin:Job","Kim:Job","Kim:David","Kim:Larsey","Larsey:Job", "Larsey:David"], Name1 = "Martin", Name2 = "David"` should return 2
1. `Connections = ["Martin:Kim","Kim:David","David:Larsey","Larsey:Job"], Name1 = "Martin", Name2 = "Job"` should return 3
1. `Connections = ["Martin:Job","Kim:Job","Martin:David","Kim:Larsey","Larsey:Job"], Name1 = "Martin", Name2 = "Job"` should return 1
1. `Connections = ["Martin:Job","Kim:Job","Kim:David","Kim:Larsey","Larsey:Job", "Larsey:David"], Name1 = "Martin", Name2 = "David"` should return 2
1. `Connections = ["Martin:Kim","Kim:David","David:Larsey","Larsey:Job"], Name1 = "Martin", Name2 = "Job"` should return 3
1. `Connections = ["Martin:Kim","Kim:David","David:Larsey","Larsey:Job", "Job:Zoe", "Zoe:Alan"], Name1 = "Martin", Name2 = "Alan"` should return 5
1. `Connections = ["Martin:Kim","Kim:David","David:Larsey","Larsey:Job", "Job:Zoe", "Zoe:Alan", "Alan:Steve"], Name1 = "Martin", Name2 = "Steve"` should return 6
### Invalid Test Cases
1. `Connections = ["Martin:Job","Kim:Job","Martin:David","Kim:Larsey","Larsey:Job"], Name1 = "Martin", Name2 = "Zoe"` should return -1
2. `Connections = [], Name1 = "Martin", Name2 = "Job"` should return -1
3. `Connections = ["Martin:Kim","Kim:David","David:Larsey"], Name1 = "Martin", Name2 = "Job"` should return -1
4. `Connections = ["Martin:Kim","Kim:David","David:Larsey"], Name1 = "Martin", Name2 = "Martin"` should return -1
5. `Connections = ["Martin:Kim","Kim:Martin"], Name1 = "Martin", Name2 = "David"` should return -1

### Edge Cases
1. `Connections = ["Martin:Kim"], Name1 = "Martin", Name2 = "Kim"` should return 1 (Single connection)
2. `Connections = ["Martin:Kim"], Name1 = "Kim", Name2 = "Martin"` should return 1 (Reverse single connection)
3. `Connections = ["Martin:Kim","Kim:Martin"], Name1 = "Martin", Name2 = "Martin"` should return -1 (Cycle but same person)
