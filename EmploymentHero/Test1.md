# Function Requirements

## Objective
Write a function that takes an array of strings as its parameter. These strings represent command-line arguments and their corresponding values. The function should validate these arguments and return an integer based on the following rules.

## Arguments
The command-line arguments that the function should recognize are:
- `--name`
- `--help`
- `--range`

## Return Values
- **-1**: If the arguments violate any of the validation rules.
- **1**: If the arguments contain `--help` and all other arguments are valid. `--help` has the highest priority.
- **0**: If the arguments are valid and do not contain `--help`.

## Validation Rules
1. An empty array is considered invalid.
2. If the argument is `--name`, the length of its value must be between 3 and 10 characters.
3. If the argument is `--range`, the value must be an integer between 10 and 100.

## Priority
- The `--help` argument has the highest priority. However, if other arguments are also passed, they must be valid; otherwise, the function should return -1.

## Test Cases

### Valid Test Cases
1. `["--name", "test"]` should return 0
2. `["--range", "15"]` should return 0
3. `["--help"]` should return 1
4. `["--help", "--name", "test"]` should return 1
5. `["--help", "--range", "15"]` should return 1
6. `["--name", "test", "--range", "15"]` should return 0
7. `["--range", "15", "--name", "test"]` should return 0
8. `["--help", "--name", "test", "--range", "15"]` should return 1
9. `["--name", "test", "--help", "--range", "15"]` should return 1

### Invalid Test Cases
1. `[]` should return -1 (Empty array)
2. `["--name"]` should return -1 (Missing value for `--name`)
3. `["--range"]` should return -1 (Missing value for `--range`)
4. `["--name", "te"]` should return -1 (Value for `--name` too short)
5. `["--name", "thisisaverylongname"]` should return -1 (Value for `--name` too long)
6. `["--range", "5"]` should return -1 (Value for `--range` too low)
7. `["--range", "105"]` should return -1 (Value for `--range` too high)
8. `["--help", "--name"]` should return -1 (Missing value for `--name`)
9. `["--help", "--range"]` should return -1 (Missing value for `--range`)
10. `["--help", "--name", "te"]` should return -1 (Value for `--name` too short)
11. `["--help", "--range", "105"]` should return -1 (Value for `--range` too high)
12. `["--name", "test", "--range"]` should return -1 (Missing value for `--range`)
13. `["--range", "15", "--name"]` should return -1 (Missing value for `--name`)
14. `["--name", "test", "--name", "test2"]` should return -1 (Duplicate `--name` argument)
15. `["--range", "15", "--range", "20"]` should return -1 (Duplicate `--range` argument)
16. `["--help", "--help"]` should return -1 (Duplicate `--help` argument)
