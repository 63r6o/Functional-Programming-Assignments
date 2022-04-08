// Exercise 1
let sqr x = x * x


// Exercise 2
let pow x n = System.Math.Pow(x,n)


// Exercise 3
let g n = n + 4


// Exercise 4
let h (x,y) = System.Math.Sqrt(x*x + y*y)


// Exercise 5.1
let rec f = function
    | 0 -> 0            
    | n -> f(n-1) + n   


// Exercise 6.1
let rec F = function
    | 0 -> 0
    | 1 -> 1
    | n -> F(n-1) + F(n-2)


// Exercise 7.1
let rec sum = function
    | (m, 0) -> m
    | (m, n) -> sum(m, n-1) + (m + n)


// Exercise 10
let dup string =  
     string + "" + string


// Exercise 11
let rec dupn s n = 
    match n with
    | 0 -> ""
    | _ -> s + " " + dupn s (n - 1)
