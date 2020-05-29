namespace Arcadia.Test

open Arcadia
open NUnit.Framework

[<RequireQualifiedAccess; TestFixture>]
module BoardTests =
    
    [<Test>]
    let ``Test making an empty board`` () =
        let uut = Board.empty ()
        Board.print uut
        ()

