namespace SeIntroGeom
open FsUnit
open NUnit.Framework
open SeIntroGeom.SeIntroGeom

[<TestFixture>]
module Tests = 

    [<Test>]
    let ``Must itersect`` () = 
        let r1 = (0, 0, 3, 3)
        let r2 = (1, 1, 4, 4)
        isRectsIntersect r1 r2 |> should be False

    [<Test>]
    let ``Must not itersect`` () = 
        let r1 = (0, 0, 3, 3)
        let r2 = (1, 1, 2, 2)
        isRectsIntersect r1 r2 |> should be False
        
    