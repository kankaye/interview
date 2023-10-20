# Function Requirements

## Objective
Write a function that takes two string parameters, `x` and `y`. The function should evaluate whether string `x` contains all the characters in string `y` in the same sequential order as they appear in `y`. The function will return a boolean value indicating the result of this evaluation. The function should not be case-sensitive and should not modify the input strings.

## Parameters
- `x`: A string that we will check for the presence and sequential order of characters from `y`.
- `y`: A string containing the characters that we want to find in `x` in the same order.

## Return Value
- **True**: If all characters in `y` are present in `x` and appear in the same sequential order as in `y`.
- **False**: Otherwise.

## Rules
1. The function should not be case-sensitive.
2. The order of characters in `y` must be maintained in `x` for the function to return True.

## Examples
- `x = "ABOUYTN", y = "AN"` should return True
- `x = "ABOUYTN", y = "NA"` should return False
- `x = "ABOUYTN", y = "AB"` should return True
- `x = "ABOUYTN", y = "F"` should return False

## Test Cases

### Valid Test Cases
1. `x = "ABOUYTN", y = "AN"` should return True
2. `x = "ABOUYTN", y = "AB"` should return True
3. `x = "ABOUYTN", y = "TN"` should return True
4. `x = "ABOUYTN", y = "BO"` should return True
5. `x = "ABOUYTN", y = ""` should return True (Empty `y` is always True)
6. `x = "ABOUYTN", y = "ATN"` should return True (Characters are in the same order)

### Invalid Test Cases
1. `x = "ABOUYTN", y = "NA"` should return False
2. `x = "ABOUYTN", y = "BA"` should return False
3. `x = "ABOUYTN", y = "F"` should return False
4. `x = "ABOUYTN", y = "Z"`
