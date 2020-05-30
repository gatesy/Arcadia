namespace Arcadia

type Board = Pebble option list list

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
 
    /// Make a move on a board.
    /// TODO support taking
    /// TODO look for P | ~P | ~P | P sequences on each axis and diagonal; remove the ~Ps.
    let move (colIndex, rowIndex, pebble) board =
        let row = List.item colIndex board
        let currentPebble = List.item rowIndex row
        
        match currentPebble with
        | Some currentPebble -> Error <| sprintf "(%d,%d) already occupied by %A" colIndex rowIndex currentPebble
        | None ->
            let newRow = (List.append (row |> List.take rowIndex) ((Some pebble) :: (List.skip (rowIndex + 1) row)))
            let newBoard = (List.append (board |> List.take colIndex) (newRow :: (List.skip (colIndex + 1) board)))
            Ok newBoard