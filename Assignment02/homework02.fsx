// Exercise 2
let minutes (h, m) =  h * 60 + m

// Exercise 1 
let timediff (h0, m0) (h1, m1) =
    minutes(h1, m1) - minutes(h0, m0)

// Exercise 3
let rec pow (s,n) =
    match n with
    | 1 -> s:string
    | _ -> s + pow(s, n-1)

// Exercise 4
let rec bin (a,b) =
    if (a=b || b=0) then 1
    else bin (a-1,b-1) + bin (a-1, b)

// Exercise 7
let curry f x y = f(x,y)

let uncurry g (x,y) = g x y