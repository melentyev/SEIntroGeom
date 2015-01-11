namespace SeIntroGeom
open FsUnit
open NUnit.Framework
open SeIntroGeom.SeIntroGeom

[<TestFixture>]
module Tests = 

    [<Test>]
    let ``Rects must itersect`` () = 
        let r1 = (0, 0, 3, 3)
        let r2 = (1, 1, 4, 4)
        isRectsIntersect r1 r2 |> should be True

    [<Test>]
    let ``Rects must not itersect`` () = 
        let r1 = (0, 0, 3, 3)
        let r2 = (1, 1, 2, 2)
        isRectsIntersect r1 r2 |> should be False
    
    [<Test>]
    let ``point in triangle`` () = 
        let t = (0, 0, 5, 0, 0, 5)
        let p = (1, 1)
        isPointInsideTriangle p t |> should be True

    [<Test>]
    let ``point not in triangle`` () = 
        let t = (0, 0, 5, 0, 0, 5)
        let p = (4, 4)
        isPointInsideTriangle p t |> should be False

    [<Test>]
    let ``point on triangle border`` () = 
        let t = (0, 0, 5, 0, 0, 5)
        let p = (0, 1)
        isPointInsideTriangle p t |> should be True