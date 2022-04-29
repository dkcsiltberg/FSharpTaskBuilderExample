task {
    let m1 f s = Seq.map f s // doing this is fine

    do! Async.Sleep 1
    do! System.Threading.Tasks.Task.Delay 1

    let m2 f (s: #seq<_>) = Seq.map f s // doing this is not fine

    try
        do! Async.Sleep 1 // this crashes
        printf "wow I made it\r\n"
    with _ ->
        printf "nope\r\n"

    do! System.Threading.Tasks.Task.Delay 1 // this just never resumes
    printf "wow I made it\r\n"

    return 1
}
|> fun f -> f.Wait()
System.Console.ReadLine () |> ignore