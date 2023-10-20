# Function Requirements

## Objective
Write a function that takes an array of strings as its parameter. These strings represent command-line arguments and their corresponding values. The function should validate these arguments and return an integer based on the following rules.

## Arguments
The command-line arguments that the function should recognize are (case-insensitive):
- `--name`
- `--help`
- `--range`

## Return Values
- **-1**: If the arguments violate any of the validation rules.
- **1**: If the arguments contain `--help` and all other arguments are valid. `--help` has the highest priority.
- **0**: If the arguments are valid and do not contain `--help`.

## Validation Rules
1. An empty array is considered invalid.
2. If the argument is `--name` (case-insensitive), the length of its value must be between 3 and 10 characters.
3. If the argument is `--range` (case-insensitive), the value must be an integer between 10 and 100.
4. Command-line arguments are case-insensitive (e.g., `--NAME` and `--name` are considered the same).

## Priority
- The `--help` argument has the highest priority. However, if other arguments are also passed, they must be valid; otherwise, the function should return -1.

## Test Cases

### Valid Test Cases
1. `["--name", "test"]` should return 0
1. `["--NAME", "test"]` should return 0
1. `["--range", "15"]` should return 0
1. `["--RANGE", "15"]` should return 0
1. `["--help"]` should return 1
1. `["--help", "--name", "test"]` should return 1
1. `["--help", "--range", "15"]` should return 1
1. `["--name", "test", "--range", "15"]` should return 0
1. `["--range", "15", "--name", "test"]` should return 0
1. `["--help", "--name", "test", "--range", "15"]` should return 1
1. `["--name", "test", "--help", "--range", "15"]` should return 1

### Invalid Test Cases
1. `[]` should return -1 (Empty array)
1. `["--name"]` should return -1 (Missing value for `--name`)
1. `["--NAME"]` should return -1 (Missing value for `--name`, case-insensitive)
1. `["--name", "te"]` should return -1 (Value for `--name` too short)
1. `["--NAME", "te"]` should return -1 (Value for `--name` too short, case-insensitive)
1. `["--name", "thisisaverylongname"]` should return -1 (Value for `--name` too long)
1. `["--NAME", "thisisaverylongname"]` should return -1 (Value for `--name` too long, case-insensitive)
1. `["--name", "te"]` should return -1 (Value for `--name` too short)
1. `["--name", "thisisaverylongname"]` should return -1 (Value for `--name` too long)
1. `["--range", "5"]` should return -1 (Value for `--range` too low)
1. `["--range", "105"]` should return -1 (Value for `--range` too high)
1. `["--help", "--name"]` should return -1 (Missing value for `--name`)
1. `["--help", "--range"]` should return -1 (Missing value for `--range`)
1. `["--help", "--name", "te"]` should return -1 (Value for `--name` too short)
1. `["--help", "--range", "105"]` should return -1 (Value for `--range` too high)
1. `["--name", "test", "--range"]` should return -1 (Missing value for `--range`)
1. `["--range", "15", "--name"]` should return -1 (Missing value for `--name`)
1. `["--name", "test", "--name", "test2"]` should return -1 (Duplicate `--name` argument)
1. `["--range", "15", "--range", "20"]` should return -1 (Duplicate `--range` argument)
1. `["--help", "--help"]` should return -1 (Duplicate `--help` argument)

### Additional Invalid Test Cases for Unrecognized Arguments
1. `["--unknown"]` should return -1 (Unrecognized argument)
2. `["--name", "test", "--unknown"]` should return -1 (Valid `--name` but unrecognized argument)
3. `["--help", "--unknown"]` should return -1 (`--help` present but unrecognized argument)
4. `["--unknown", "--range", "15"]` should return -1 (Valid `--range` but unrecognized argument)
5. `["--unknown", "--unknown2"]` should return -1 (Multiple unrecognized arguments)
6. `["--name", "test", "--unknown", "--range", "15"]` should return -1 (Valid `--name` and `--range` but unrecognized argument)

