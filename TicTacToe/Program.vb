Imports System
Imports System.Diagnostics.Tracing

Module Program
    Sub Main(args As String())
        Console.WriteLine("Witaj w grze TicTacToe")
        Menu()
        'StartGame()
    End Sub

    Sub Menu()

        Dim singleChar As Char

        While singleChar <> "2"
            Console.Clear()
            Console.WriteLine()
            Console.WriteLine("Menu:")
            Console.WriteLine("1. Nowa gra")
            Console.WriteLine("2. Koniec")

            singleChar = Console.ReadLine()
            singleChar = CChar(CStr(singleChar).ToLower)

            If singleChar = "1" Then
                SubMenu()
            End If

        End While

        If singleChar = "2" Then
            System.Environment.Exit(0)
        End If

    End Sub

    Sub SubMenu()

        Dim singleChar2 As Char

        While singleChar2 <> "3"
            Console.Clear()
            Console.WriteLine()
            Console.WriteLine("Kto zaczyna?")
            Console.WriteLine("1. Ja")
            Console.WriteLine("2. Komputer")
            Console.WriteLine("3. Wyjdz")

            singleChar2 = Console.ReadLine()
            singleChar2 = CChar(CStr(singleChar2).ToLower)

            If singleChar2 = "1" Then
                StartGame()
            End If

        End While

        If singleChar2 = "3" Then
            Menu()
        End If
    End Sub
    Sub StartGame()

        Dim row, cell As Integer
        Dim field(2, 2) As Char
        Dim counter As Integer
        Dim gameStatus As Boolean

        Console.WriteLine()
        CreateField(field)

        counter = 0
        Do
            DrawField(field)

            Console.WriteLine()
            Console.Write("Podaj wiersz: ")
            row = Console.ReadLine()
            Console.Write("Podaj kolumne: ")
            cell = Console.ReadLine()
            Console.WriteLine()
            Console.Clear()

            If counter < 9 Then
                YourMove(row, cell, field)
                counter += 1
            End If

            gameStatus = checkState(field, "X")
            If gameStatus = True Then
                Console.WriteLine("YOU: Wygra³eœ")
                Exit Do
            End If

            If counter < 9 Then
                CpuMove(field)
                counter += 1
            End If

            gameStatus = checkState(field, "O")

            If gameStatus = True Then
                Console.WriteLine("CPU: Wygra³")
                Exit Do
            End If

        Loop Until counter = 9

        Console.WriteLine()
        If counter = 9 Then
            Console.Write("Koniec gry: Remis")
        End If
        Console.ReadLine()
        SubMenu()

        Console.ReadLine()
    End Sub

    Sub CreateField(field(,) As Char)

        For i As Integer = 0 To 2
            For j As Integer = 0 To 2
                field(i, j) = "_"
            Next
        Next

    End Sub

    Sub DrawField(field(,) As Char)
        For i = 0 To 2
            For j = 0 To 2
                If j < 2 Then
                    Console.Write(field(i, j) & " ")
                Else
                    Console.WriteLine(field(i, j) & " ")
                End If
            Next
        Next
    End Sub

    Sub YourMove(row As Integer, cell As Integer, field(,) As Char)
        Do
            If field(row, cell) <> "_" Then
                Console.WriteLine("You: Pole (" & row & "," & cell & ") jest zajete!")
            End If
        Loop Until field(row, cell) = "_"
        field(row, cell) = "X"

    End Sub
    Sub CpuMove(field(,) As Char)

        Dim row As Integer
        Dim cell As Integer

        Do
            row = 2 * Rnd()
            cell = 2 * Rnd()

            If field(row, cell) <> "_" Then
                Console.WriteLine("CPU: Pole (" & row & "," & cell & ") jest zajete!")
            End If
        Loop Until field(row, cell) = "_"
        field(row, cell) = "O"
    End Sub

    Function checkState(field(,) As Char, who As Char)

        Dim gameStatus As Boolean

        For i As Integer = 0 To 2
            If field(i, 0) = who And field(i, 1) = who And field(i, 2) = who Then
                gameStatus = True
            End If
            If field(0, i) = who And field(1, i) = who And field(2, i) = who Then
                gameStatus = True
            End If
        Next

        If field(0, 0) = who And field(1, 1) = who And field(2, 2) = who Then
            gameStatus = True
        End If

        If field(0, 2) = who And field(1, 1) = who And field(2, 0) = who Then
            gameStatus = True
        End If

        Return gameStatus

    End Function

End Module
