namespace Arcadia

/// Functions for interacting with a Pente board
[<RequireQualifiedAccess>]
module Board =
    
    let empty () =
        List.init 19 (fun _ -> List.init 19 (fun _ -> None))

    let print board : unit =
        board
        |> List.iter
               (fun row ->
                    row |> List.iter
                        (fun cell ->
                            match cell with
                            | Some White -> "|W"
                            | Some Black -> "|B"
                            | None -> "|-"
                            |> printf "%s"
                        )
                    printfn "|"
                    
                )
