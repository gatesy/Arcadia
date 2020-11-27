namespace Arcadia.Service

open Giraffe

type Pebble = White | Black

type Position = 
    {
        Pebble : Pebble
        X : int
        Y : int
    }

[<RequireQualifiedAccess>]
module Board =
    let testBoard =
        [ 
            { Pebble = Black; X = 10; Y = 10 }
            { Pebble = Black; X = 9; Y = 9 }
            { Pebble = White; X = 8; Y = 9 }
            { Pebble = White; X = 1; Y = 1 }
            { Pebble = Black; X = 17; Y = 17 }
        ]

    let boardHandler (board : Position list) : HttpHandler =
        json board
