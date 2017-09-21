Public Class Form1

    Dim VelocidadY As Integer = 2
    Dim VelocidadX As Integer = 2

    Dim LimiteX As Integer = Me.Width
    Dim LimiteY As Integer = Me.Height

    Dim RectanguloAlto As Integer = 20
    Dim RectanguloAncho As Integer = 120

	' Posicion inicial de la pelota
	Dim PosicionYPelota As Integer = CSng(Me.Height / 2)
    Dim PosicionXPelota As Integer = CSng(Me.Width / 2)
	
	' Posición inicial del rectángulo
    Dim PosicionYRectangulo As Integer = CSng(Me.Height)
    Dim PosicionXRectangulo As Integer = CSng(Me.Width / 2)

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ' Por cada cuadro de animación proceder a dibujar 
        ' el desplazamiento de la pelota
        Me.MoverPelota()
    End Sub

    Private Sub MoverPelota()

	    ' En el presente cuadro se borra todo gráfico dibujado en el anterior cuadro y se 
        ' dibuja la posición actualizada de la pelota
        Me.Refresh()

        Dim Grafico As Graphics = Me.CreateGraphics

		' Dibuja la pelota en sus coordenadas x e y actualizadas
        Grafico.FillEllipse(Brushes.Blue, PosicionXPelota, PosicionYPelota, 30, 30)

		' Dibuja el rectángulo en las coordenadas x e y 
        ' dependiendo de la posición del mouse sobre el formulario
        Grafico.FillRectangle(Brushes.Green, Me.PosicionXRectangulo, _ 
			Me.PosicionYRectangulo, Me.RectanguloAncho, Me.RectanguloAlto)

		' Si los bordes horizontales de la pelota toca el borde izquierdo o derecho
        ' del formulario entonces cambiar su dirección horizontal
        If PosicionXPelota <= 0 Or PosicionXPelota + 35 >= Me.Width Then
            VelocidadX *= -1
        End If

		' Si el borde superio de la pelota toca el borde superior del formulario
        ' entonces cambiar su dirección haciendo que rebote hacia abajo
        If PosicionYPelota <= 0 Then
            VelocidadY *= -1
        End If

		' Si el borde inferior de la pelota pasa por la altura del borde superior
        ' del rectángulo y los bordes horizontales de la pelota se encuentran
        ' dentro del rango horizontal del rectángulo es porque 
        ' la pelotita está tocando el rectángulo, debe rebotar hacia arriba
        ' pero en dirección contraria
        If PosicionYPelota + 28 >= Me.PosicionYRectangulo And _ 
		PosicionYPelota + 28 <= Me.PosicionYRectangulo + 5 And _ 
		PosicionXPelota >= Me.PosicionXRectangulo - 15 And _ 
		PosicionXPelota <= Me.PosicionXRectangulo + Me.RectanguloAncho + 15 Then
            VelocidadY *= -1
        End If

		' Mover la pelotita vertical y horizontalmente uniformemente
        PosicionXPelota += VelocidadX
        PosicionYPelota += VelocidadY

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		' Iniciar el timer
        Timer1.Enabled = True
    End Sub

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
		' Si mueve el mouse mueve la localización del rectángulo
        If e.X <= Me.Width - (Me.RectanguloAncho) Then
            Me.PosicionXRectangulo = e.X
        End If
    End Sub

End Class
