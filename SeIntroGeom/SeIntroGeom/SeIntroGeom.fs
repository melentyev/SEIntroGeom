namespace SeIntroGeom

module SeIntroGeom =
    type Rect = int * int * int * int

    let private segInt1d a b c d = 
        let a, b = min a b, max a b
        let c, d = min c d, max c d
        let x, y = max a c, min b d
        if x > y then None else Some (x, y)

    let private normRect (x1, y1, x2, y2) = 
        min x1 x2, min y1 y2, max x1 x2, max y1 y2
    let private  segIsInsideSeg1d a b c d = 
        c < a && d > b

    let private rectIsInsideRect (r1: Rect) (r2: Rect) = 
        let x1, y1, x2, y2     = r1
        let x1', y1', x2', y2' = r2 
        segIsInsideSeg1d x1 x2 x1' x2' && segIsInsideSeg1d y1 y2 y1' y2'

    let isRectsIntersect (r1: Rect) (r2: Rect) =
        let r1 = normRect r1
        let r2 = normRect r2
        let x1, y1, x2, y2     = r1
        let x1', y1', x2', y2' = r2 
        Option.isSome (segInt1d x1 x2 x1' x2') && Option.isSome (segInt1d y1 y2 y1' y2') 
            && not (rectIsInsideRect r1 r2) && not (rectIsInsideRect r2 r1)
    