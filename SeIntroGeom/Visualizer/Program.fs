open System
open System.Drawing
open System.Windows.Forms
open SeIntroGeom.SeIntroGeom

let rnd = new Random()
let W = 1000
let H = 500
let nextW () = rnd.Next(30, W - 30)
let nextH () = rnd.Next(30, H - 90)

let genRect () =
    nextW (), nextH (), nextW (), nextH ()

let genTriangle () = 
    nextW(), nextH(), nextW(), nextH(), nextW(), nextH()

let genPoint () = 
    nextW(), nextH()

let drawableRect (a, b, c, d) = 
    let a, c = min a c, max a c
    let b, d = min b d, max b d
    new Rectangle(a, b, c - a, d - b)

let drawablePoint (a, b) = 
    new Rectangle(a - 2, b - 2, 5, 5)

let run() =
    let r1 = ref <| (-1, -1, -1, -1)
    let r2 = ref <| (-1, -1, -1, -1)
    let t = ref <| genTriangle ()
    let p = ref <| genPoint ()
    let triangleMode = ref false
    let form = new Form(Width = W, Height = H)
    let st = new StatusBar()
    let drawTriangle (a, b, c, d, e, f) (g: Graphics) =
        g.DrawLine(new Pen(Color.Black), new Point(a, b), new Point (c, d))
        g.DrawLine(new Pen(Color.Black), new Point(c, d), new Point (e, f))
        g.DrawLine(new Pen(Color.Black), new Point(e, f), new Point (a, b))

    form.Paint.Add <| fun e ->
        if !triangleMode then 
            drawTriangle !t e.Graphics
            e.Graphics.FillEllipse(Brushes.Blue, drawablePoint !p)
        else
            e.Graphics.DrawRectangle(new Pen(Color.Black), drawableRect !r1)
            e.Graphics.DrawRectangle(new Pen(Color.Blue), drawableRect !r2)
        ()

    let mir = new MenuItem("Rectangles (task #1)", fun _ _ -> 
        r1 := genRect()  
        r2 := genRect()
        form.Invalidate()
        triangleMode := false
        st.Text <- if isRectsIntersect !r1 !r2 then "Intersect" else "No intersect"
    )
    let mit = new MenuItem("Triangle and point (task #5)", fun _ _ -> 
        t := genTriangle ()
        p := genPoint ()
        form.Invalidate()
        triangleMode := true
        st.Text <- if isPointInsideTriangle !p !t then "Inside" else "Outside"
    )
    let m = new MainMenu([|mir; mit;|])
    form.Controls.Add(st)
    form.Menu <- m
    Application.Run(form)

[<EntryPoint>]
let main argv = 
    run ()
    0