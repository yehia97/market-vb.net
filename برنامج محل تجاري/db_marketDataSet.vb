Partial Class db_marketDataSet
    Partial Public Class itemsDataTable
        Private Sub itemsDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.IDColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class
End Class
