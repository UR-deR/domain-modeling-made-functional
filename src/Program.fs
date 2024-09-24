// For more information see https://aka.ms/fsharp-console-apps
printfn "Hello from F#"

type AppleVariety = 
    | Fuji
    | GrannySmith
    | GoldenDelicious

type BananaVariety = 
    | Cavendish
    | RedDacca

type CherryVariety = 
    | Bing
    | Rainier

type FruitSnack = 
    | Apple of AppleVariety
    | Banana of BananaVariety
    | Cherry of CherryVariety

let fuji = Apple Fuji

printfn "%A" fuji

type Person = { First: string; Last: string }

let person = { First = "John"; Last = "Doe" }

let { First = first; Last = last } = person

type OrderQuantity = | UnitQuantity of int | KilogramQuantity of decimal

let anOrderQuantity = UnitQuantity 10

let anKilogramQuantity = KilogramQuantity 2.5m

let printQuantity aOrderQty = 
    match aOrderQty with
    | UnitQuantity uQty -> printfn "%i units" uQty
    | KilogramQuantity qty -> printfn "%f kg" qty

printQuantity anOrderQuantity
