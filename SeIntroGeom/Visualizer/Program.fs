open System
open System.Drawing
open System.Windows.Forms
open SeIntroGeom.SeIntroGeom

let rnd = new Random()
let W = 1000
let H = 500
let nextW () = rnd.Next(30, W - 30)
let nextH () = rnd.Next(30, H - 70)

let genRect () =
    nextW (), nextH (), nextW (), nextH ()

let drawableRect (a, b, c, d) = 
    let a, c = min a c, max a c
    let b, d = min b d, max b d
    new Rectangle(a, b, c - a, d - b)

[<EntryPoint>]
let main argv = 
    let a = ref <| genRect ()
    let b = ref <| genRect ()
    let form = new Form(Width = W, Height = H)
    let st = new StatusBar()
    form.Paint.Add <| fun e ->
        e.Graphics.DrawRectangle(new Pen(Color.Black), drawableRect !a)
        e.Graphics.DrawRectangle(new Pen(Color.Blue), drawableRect !b)
        ()
    let mi = new MenuItem("Generate", fun _ _ -> 
        a := genRect()  
        b := genRect()
        form.Invalidate()
        st.Text <- if isRectsIntersect !a !b then "Intersect" else "No intersect"
    )
    let m = new MainMenu([|mi|])
    form.Controls.Add(st)
    form.Menu <- m
    Application.Run(form)
    0
