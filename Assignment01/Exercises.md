# Homework 01
---
### _Exercise 1_
Write a function sqr:int->int so that sqr x returns x^2
### _Exercise 2_
Write a function pow : float -> float -> float so that pow x n returns x n.
You can use the library function: System.Math.Pow.
### _Exercise 3_
Declare a function g: int -> int, where g(n) = n + 4.
### _Exercise 4_
Declare a function h: float * float -> float, where h(x, y) = sqrt(x2 + y2). Hint: Use the function System.Math.Sqrt.
### _Exercise 5.1_
Declare a recursive function f: int -> int, where
f(n) = 1+2+···+(n−1)+n
for n ≥ 0.
_(Hint: use two clauses with 0 and n as patterns.)_
State the recursion formula corresponding to the declaration.
### _Exercise 5.2_
Give an evaluation for f(4).

>Starting with argument 4, on each recursion we will add up to 4, where n = n-1 each time
>f(4)             
>4 + (4-1) + (3-1) + (2-1) + (1-1)
>10

### _Exercise 6.1_
The sequence F0 , F1 , F2 , . . . of Fibonacci numbers is defined by:
F0 = 0
F1 = 1
Fn = Fn−1 + Fn−2
Thus, the first members of the sequence are 0, 1, 1, 2, 3, 5, 8, 13, . . ..
Declare an F# function to compute Fn. Use a declaration with three clauses, where the patterns correspond to the three cases of the above definition.
### _Exercise 6.2_
Give an evaluations for F4.

>Starting with argument 4, we first hit the last pattern (n):
>F(3) + F(2)
>Each of them will hit the last pattern (n):
>(F(2) + F(1)) + (F(1) + F(0))
>(F(1) + F(0)) + 1 + 1 + 0
>1 + 0 + 1 + 1 + 0
>3

### _Exercise 7.1_
Declare a recursive function sum: int * int -> int, where
sum(m, n) = m + (m + 1) + (m + 2) + · · · + (m + (n − 1)) + (m + n)
for m ≥ 0 and n ≥ 0.
_(Hint: use two clauses with (m,0) and (m,n) as patterns.)_
### _Exercise 7.2_
Give the recursion formula corresponding to the declaration.

> (m, n) where m,n ≥ 0
> m(0) = 0
> m(n) = m + m(n-1)

### _Exercise 8_
Determine a type for each of the expressions:
| Expression | Type |
| ------ | -------|
|(System.Math.PI, fact -1)|float * int|
|fact(fact 4)|int|
|power(System.Math.PI, fact 2)|float|
|(power, fact)|(float * float -> float) * (int -> int)|

### _Exercise 9_
Consider the declarations:
```
let a = 5;;
let f a = a + 1;;
let g b = (f b) + a;;
```

Find the environment obtained from these declarations and write the evaluations of the expressions f 3 and g 3.

>f 3 = 3 + 1 = **4**
>g 3 = (f 3) + 5 = 4 + 5 = **9**

### _Exercise 10_
Write a function dup:string->string that concatenates a string with itself.
You can either use + or ˆ. For example:

```
val dup : string -> string
dup "Hi ";;
val it : string = "Hi Hi "
```

### _Exercise 11_
Write a function dupn:string->int->string so that dupn s n creates the concatenation
of n copies of s. For example:

```
val dupn : string -> int -> string
dupn "Hi " 3;;
val it : string = "Hi Hi Hi "
```
