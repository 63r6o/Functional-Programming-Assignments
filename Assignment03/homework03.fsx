module a2
// Exercise 1
let rec downTo n =
    if n = 0 then
        [ ]
    else
        [ n ] @ downTo (n - 1)

let rec downTo2 n =
    match n with
    | 0 -> [ ]
    | n when n > 0 -> [ n ] @ downTo2 (n - 1)
    | n when n < 0 -> [ n ] @ downTo2 (n + 1) // ?

// Exercise 2
let rec removeOddIdx (xs: int list) =
    match xs with
    | [] -> []
    | x :: y :: xs' -> [ x ] @ removeOddIdx xs'
    | x :: xs' -> [ x ] @ removeOddIdx xs'

// Exercise 3
let rec combinePair (xs: int list) =
    match xs with
    | [] -> []
    | x :: y :: xs' -> [ (x, y) ] @ combinePair xs'
    | x :: xs' -> []

// Exercise 4

// Money tuple addition
let (^+^) a b =
    let (poundA, schillingA, penceA) = a
    let (poundB, schillingB, penceB) = b
    let penceA = (poundA * 12 * 20) + (schillingA  * 12) + penceA

    let penceB = (poundB * 12 * 20) + (schillingB  * 12) + penceB

    let pence = penceA + penceB

    (pence / 12 / 20, pence / 12 % 20, pence % 12)


// Money tuple subtraction
let (^-^) a b =
    let (poundA, schillingA, penceA) = a
    let (poundB, schillingB, penceB) = b

    let penceA = (poundA * 12 * 20) + (schillingA  * 12) + penceA

    let penceB = (poundB * 12 * 20) + (schillingB  * 12) + penceB

    let pence = abs (penceA - penceB)

    (pence / 12 / 20, pence / 12 % 20, pence % 12)

// 20 shilling = 1 pound, 12 pence = 1 shilling
type Money =
    { pound: int
      shilling: int
      pence: int }

// Money record addition
let (|+|) a b =
    let (x,y,z) = (a.pound, a.shilling, a.pence) ^+^ (b.pound, b.shilling, b.pence)
    {pound=x; shilling=y; pence=z}

// Money record subtraction
let (|-|) a b =
    let (x,y,z) = (a.pound, a.shilling, a.pence) ^-^ (b.pound, b.shilling, b.pence)
    {pound=x; shilling=y; pence=z}


// Exercise 5

//      1. Declare infix for addition and multiplication
let (.+) (a: float, b: float) (c: float, d: float) = (a + c, b + d)

let (.*) (a: float, b: float) (c: float, d: float) = ((a * c) - (b * d), (b * c) + (a * d))

//      2. Declare infix for subtraction and division
let (.-) (a: float, b: float) (c: float, d: float) = (a - c, b - d)

let (./) (a, b) (c, d) =
    if (a = 0. && b = 0.) || (c = 0. && d = 0.) then
        failwith "error: a and b both zero"
    else
         (a,b) .* (c / (pown c 2 + pown d 2), -d / (pown c 2 + pown d 2))

//      3. Use 'let' expressions in division to avoid repeated evals
let (../) (a: float, b: float) (c: float, d: float) =
    if a = 0. && b = 0. then
        failwith "error: a and b both zero"
    else
        let cPow2 = c ** 2.0
        let dPow2 = d ** 2.0
        let cdPow = cPow2 + dPow2
        (a,b) .* (c / (cdPow), -d / (cdPow))



// Exercise 6
let rec altsum =
    function
    | [] -> 0
    | x0 :: xs' -> x0 + -altsum xs'
