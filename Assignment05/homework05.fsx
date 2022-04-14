// util
type 'a BinTree =
    | Leaf
    | Node of 'a * 'a BinTree * 'a BinTree


let intBinTree =
    Node(43, Node(25, Node(56, Leaf, Leaf), Leaf), Node(562, Leaf, Node(78, Leaf, Leaf)))

// Exercise 1
let rec inOrder tree =
    match tree with
    | Leaf -> []
    | Node(n, lTree, rTree) -> (inOrder lTree) @ [n] @ (inOrder rTree)

// Exercise 2
let rec mapInOrder f tree =
    match tree with
    | Leaf -> Leaf
    | Node(n, lTree, rTree) -> Node(f n, mapInOrder f lTree, mapInOrder f rTree)

// TODO: example, might have to change it to actual in order traversal

// Exercise 3
let rec foldInOrder f a tree =
    match tree with
    | Leaf -> a
    | Node(n, lTree, rTree) ->
        let a' = (foldInOrder f a lTree)
        let a'' = (f n a')
        (foldInOrder f a'' rTree)

// Exercise 4

// Declaration for the abstract syntax
type aExp =                 (* Arithmetical expressions *)
    | N of int              (* numbers *)
    | V of string           (* variables *)
    | Add of aExp * aExp    (* addition *)
    | Mul of aExp * aExp    (* multiplication *)
    | Sub of aExp * aExp    (* subtraction *)

type bExp =                 (* Boolean expressions *)
    | TT                    (* true *)
    | FF                    (* false *)
    | Eq of aExp * aExp     (* equality *)
    | Lt of aExp * aExp     (* less than *)
    | Neg of bExp           (* negation *)
    | Con of bExp * bExp    (* conjunction *)

type stm =                      (* statements *)
    | Ass of string * aExp      (* assignment *)
    | Skip
    | Seq of stm * stm          (* sequential composition *)
    | ITE of bExp * stm * stm   (* if-then-else *)
    | While of bExp * stm       (* while *)
    | RU of bExp * stm          (* repeat until*)
    | IT of bExp * stm          (* if-then *)

// Declarations
let rec A a s =
    match a with
    | N n -> n
    | V v -> Map.find v s
    | Add (a1, a2) -> A a1 s + A a2 s
    | Mul (a1, a2) -> A a1 s * A a2 s
    | Sub (a1, a2) -> A a1 s - A a2 s

let rec B b s =
    match b with
    | TT -> true
    | FF -> false
    | Eq (b1, b2) -> A b1 s = A b2 s
    | Lt (b1, b2) -> A b1 s < A b2 s
    | Neg b -> not (B b s)
    | Con (b1, b2) -> B b1 s = true && B b2 s = true

let rec I stm s =
    match stm with
    | Ass (x, a) -> Map.add x (A a s) s
    | Skip -> s
    | Seq (stm1, stm2) -> s |> I stm1 |> I stm2
    | ITE (b, stm1, stm2) -> if (B b s) then I stm1 s else I stm2 s
    | While (b, stm) -> I (ITE(b, (Seq(stm, While(b, stm))), Skip)) s
    | RU (b, stm) -> I (Seq(stm, While(Neg(b), stm))) s
    | IT (b, stm) -> if (B b s) then I stm s else I Skip s