# Homework 03
---
### Exercise 1
Write a function

```
downTo:int->int list
```

so that ```downTo n``` returns the n-element list [n; n-1; . . .; 1].  
You must use if-then-else expressions to
define the function.
Secondly define the function ```downTo2``` having same semantics as ```downTo```. This time you must use pattern
matching.

### Exercise 2
Write a function

```
removeOddIdx:int list->int list
```

so that removeOddIdx xs removes the odd-indexed elements from the list xs:

```
removeOddIdx [x0; x1; x2; x3; x4; ...] = [x0; x2; x4; ...]
removeOddIdx [] = []
removeOddIdx [x0] = [x0]
```

### Exercise 3
Write a function
```combinePair:int list->(int*int) list```
so that ```combinePair xs``` returns the list with elements from xs combined into pairs.  
If xs contains an odd
number of elements, then the last element is thrown away:

```
combinePair [x1; x2; x3; x4] = [(x1,x2);(x3,x4)]
combinePair [x1; x2; x3] = [(x1,x2)]
combinePair [] = []
combinePair [x1] = []
```

Hint: Try use pattern matching.

### Exercise 4
The former British currency had 12 pence to a shilling and 20 shillings to a pound.  
Declare functions to add and subtract two amounts, represented by triples ```(pounds, shillings, pence) ```of integers, and declare the functions when a representation by records is used. Declare the func- tions in infix notation with proper precedences, and use patterns to obtain readable declarations.

### Exercise 5

The set of complex numbers is the set of pairs of real numbers. Complex numbers behave almost like real numbers if addition and multiplication are defined by:

```
(a,b)+(c,d) = (a+c,b+d)
(a, b) · (c, d) = (ac − bd, bc + ad)
```

1. Declare suitable infix functions for addition and multiplication of complex numbers.
2. The inverse of ```(a,b)``` with regard to addition,that is, ```−(a,b)```, is ```(−a,−b)```, and the inverse of ```(a, b)``` with regard to multiplication, that is, ```1/(a, b)```, is ```(a/(a2 + b2)```, ```−b/(a2 + b2))``` (provided that a and b are not both zero). Declare infix functions for subtraction and division of complex
numbers.
3. Use ```let```-expressions in the declaration of the division of complex numbers in order to avoid
repeated evaluation of identical subexpressions.

### Exercise 6
Give a declaration for ```altsum``` containing just two clauses.

```
let rec altsum = function
    |[] ->0
    | [x] ->x
    | x0::x1::xs -> x0 - x1 + altsum xs;;
val altsum : int list -> int
  ```