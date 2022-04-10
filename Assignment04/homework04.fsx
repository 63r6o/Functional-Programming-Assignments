module a2
// Exercise 1
let explode (s: string) = List.ofArray (s.ToCharArray())

let rec explode2 (s: string) =
    let length = s.Length - 1
    match length with
    | -1 -> []
    | 0 -> [s.Chars(length)]
    | _ ->
        explode2 (s.Remove(length, 1))
        @ [ s.Chars(length) ]
// Exercise 2
let implode list =
    List.foldBack (fun x y -> x.ToString() + y.ToString()) list ""

let implodeRev list =
    List.fold (fun x y -> y.ToString() + x.ToString()) "" list

// Exercise 3
let toUpper (s: string) =
    implode (List.map (fun x -> System.Char.ToUpper(x)) (explode s))

// explode >> map >> implode
let toUpper1 (s: string) =
    (explode >> (List.map (fun x -> System.Char.ToUpper(x))) >> implode) s

let toUpper2 (s: string) =
    implode (explode s |> List.map (fun x -> (System.Char.ToUpper(x))))

// Exercise 4
let rec palindrome (s: string) =
    let last = s.Length - 1
    let sUp = s.ToUpper()
    match last with
    | -1 -> true
    | _ when (sUp.[0] = sUp.[last]) -> palindrome s.[1..last-1]
    | _ -> false

// Exercise 5
let rec ack t =
    match t with
    | (0, n) -> n + 1
    | (m, 0) when m > 0 -> ack (m - 1, 1)
    | (m, n) when (m > 0 && n > 0) -> ack (m - 1, ack (m, n - 1))
// ack(3, 11) = 16381

// Exercise 6
let time f =
    let start = System.DateTime.Now in
    let res = f () in
    let finish = System.DateTime.Now in
    (res, finish - start)

let timeArg1 f a = time (fun () -> f a)


// Exercise 7
let rec downto1 f (n, e) =
    match n with
    | n when n <= 0 -> e
    | 1 -> f (1, e)
    | _ -> f (n,downto1 f (n-1, e))

// factorial function using downto1 for recursion.
let fact n =
    match n with
    | n when n >= 0 -> downto1 (fun (x,y) -> x * y) (n,1)
    | _ -> failwith "fact only works on positive numbers" 
    

let buildList g n = downto1 (fun (x, ys) -> ys @ [g x]) (n, [])

