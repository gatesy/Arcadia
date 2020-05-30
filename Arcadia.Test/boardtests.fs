namespace Arcadia.Test

open Arcadia
open NUnit.Framework

[<RequireQualifiedAccess; TestFixture>]
module BoardTests =

    [<Test>]
    let ``Test making an empty board`` () =
        let uut = Board.empty ()

        let result =
            Ok uut
            |> Result.bind (Board.move (9, 9, White))
            |> Result.bind (Board.move (10, 10, Black))

        match result with
        | Ok board -> Board.print board
        | Error message -> printfn "Error: %s" message

        ()

    [<Test>]
    let ``Test making a bad move`` () =
        let board = Board.empty () |> Board.move (0, 0, White)

        let result = board |> Result.bind (Board.move (0, 0, Black))

        match result with
        | Ok _ -> Assert.Fail()
        | Error message -> printfn "%s" message
