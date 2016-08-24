open Marten
open System
open System.Linq

[<CLIMutable>]
type User = {
    Id : Guid
    Name : string
}

[<EntryPoint>]
let main argv = 
    let store = DocumentStore.For("host=localhost;database=marten_test;password=mypassword;username=someuser");
    use session = store.LightweightSession()
    let user = { Id = Guid.NewGuid() ; Name = "Darth Vader"}
    session.Store(user)
    session.SaveChanges()
    let queryUser =session
                    .Query<User>()
                    .Where(fun x -> x.Name = "Darth Vader")
                    .Single();
    printfn "%A" argv
    0 // return an integer exit code
