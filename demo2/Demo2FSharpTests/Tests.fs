namespace Demo2FSharpTests

open TUnit.Core
open TUnit.Assertions
open TUnit.Assertions.Extensions
open TUnit.Assertions.FSharp.Operations

type Tests() =

    [<Test>]
    member _.Assert_Something() =
        async {
            let result = 1 + 2
            do! check (Assert.That(result).IsEqualTo(3))
        }
