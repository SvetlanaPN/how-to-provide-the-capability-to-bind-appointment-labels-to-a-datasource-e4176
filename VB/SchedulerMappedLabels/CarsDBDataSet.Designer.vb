﻿' Developer Express Code Central Example:
' How to provide the capability to bind appointment labels to a datasource
' 
' Due to numerous requests from our customers regarding the capability to bind
' appointment labels/statuses to a datasource, we have created this sample. Note
' that in the past, we tried to address this issue in the context of the following
' examples:
' http://www.devexpress.com/scid=E2028
' http://www.devexpress.com/scid=E2087
' They
' illustrate how to load labels form an external datasource. However, one
' limitation is still there. It is related to the default meaning of the
' Appointment.LabelId Property
' (http://documentation.devexpress.com/#CoreLibraries/DevExpressXtraSchedulerAppointment_LabelIdtopic).
' The value of this property represents an index of a label in the
' AppointmentStorage.Labels
' (http://documentation.devexpress.com/#WindowsForms/DevExpressXtraSchedulerAppointmentStorage_Labelstopic)
' (this label is used for this appointment).This mean that once you remove a
' particular label for this collection, indexes will be shifted. Take a moment to
' look at the http://www.devexpress.com/scid=Q413689 ticket, which describes this
' issue in detail.
' Apparently, a more advanced labels/status identification
' mechanism is required. This example illustrates how to implement this mechanism
' for labels (you can use the same approach for statuses) by extending the
' SchedulerControl Class
' (http://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraSchedulerSchedulerControltopic).
' The main idea of the approach illustrated here is to define a separate
' datasource for appointment labels (the LabelsDataSource property) and mapped
' field names for Id, Color and DisplayName (the LabelIdMappedName,
' LabelColorMappedName and LabelDisplayNameMappedName properties). If the
' datasource is not specified, we are using default label items (see the
' PopulateDefaultLabels() method). Otherwise, labels from a datasource are used.
' Note that the Appointment.LabelId property has another meaning in this scenario.
' The value of this property is used to look up a corresponding label item in the
' SchedulerControl.AppointmentViewInfoCustomizing Event
' (http://documentation.devexpress.com/#WindowsForms/DevExpressXtraSchedulerSchedulerControl_AppointmentViewInfoCustomizingtopic)
' in order to assign a color defined in this label to the appointment. In
' addition, we handle the SchedulerControl.PopupMenuShowing Event
' (http://documentation.devexpress.com/#WindowsForms/DevExpressXtraSchedulerSchedulerControl_PopupMenuShowingtopic)
' to populate the LabelSubMenu with custom menu items created on the fly based on
' the rows in the datasource with labels.
' To correctly display custom
' appointments' labels in the EditAppointmentForm, we override the UpdateFormCore
' and edtLabel_EditValueChanged methods in a corresponding EditAppointmentForm
' descendant. The important thing is that a SchedulerStorage instance should
' contain custom appointments' labels in its internal collection. We use the
' SchedulerControl.PopulateLabelsStorage method to replace the collection of
' pre-defined labels with a custom one.
' 
' Note that we are using a custom-made
' DataBindingController class to operate with a label datasource in a generic
' manner. This means that our approach should work correctly regardless of the
' actual datasource type, be it a DataTable or a List<T>.
' Here is a screenshot
' that illustrates meaning of the Appointment.LabelId property (pay attention to
' the CarScheduling.Label and Labels.Id field values):
' 
' Finally, we have
' implemented design-time support for the aforementioned properties:
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E4176

' Developer Express Code Central Example:
' How to provide the capability to bind appointment labels to a datasource
' 
' Due to numerous requests from our customers regarding the capability to bind
' appointment labels/statuses to a datasource, we have created this sample. Note
' that in the past, we tried to address this issue in the context of the following
' examples:
' http://www.devexpress.com/scid=E2028
' http://www.devexpress.com/scid=E2087
' They
' illustrate how to load labels form an external datasource. However, one
' limitation is still there. It is related to the default meaning of the
' Appointment.LabelId Property
' (http://documentation.devexpress.com/#CoreLibraries/DevExpressXtraSchedulerAppointment_LabelIdtopic).
' The value of this property represents an index of a label in the
' AppointmentStorage.Labels
' (http://documentation.devexpress.com/#WindowsForms/DevExpressXtraSchedulerAppointmentStorage_Labelstopic)
' (this label is used for this appointment).This mean that once you remove a
' particular label for this collection, indexes will be shifted. Take a moment to
' look at the http://www.devexpress.com/scid=Q413689 ticket, which describes this
' issue in detail.
' Apparently, a more advanced labels/status identification
' mechanism is required. This example illustrates how to implement this mechanism
' for labels (you can use the same approach for statuses) by extending the
' SchedulerControl Class
' (http://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraSchedulerSchedulerControltopic).
' The main idea of the approach illustrated here is to define a separate
' datasource for appointment labels (the LabelsDataSource property) and mapped
' field names for Id, Color and DisplayName (the LabelIdMappedName,
' LabelColorMappedName and LabelDisplayNameMappedName properties). If the
' datasource is not specified, we are using default label items (see the
' PopulateDefaultLabels() method). Otherwise, labels from a datasource are used.
' Note that the Appointment.LabelId property has another meaning in this scenario.
' The value of this property is used to look up a corresponding label item in the
' SchedulerControl.AppointmentViewInfoCustomizing Event
' (http://documentation.devexpress.com/#WindowsForms/DevExpressXtraSchedulerSchedulerControl_AppointmentViewInfoCustomizingtopic)
' in order to assign a color defined in this label to the appointment. In
' addition, we handle the SchedulerControl.PopupMenuShowing Event
' (http://documentation.devexpress.com/#WindowsForms/DevExpressXtraSchedulerSchedulerControl_PopupMenuShowingtopic)
' to populate the LabelSubMenu with custom menu items created on the fly based on
' the rows in the datasource with labels.
' To correctly display custom
' appointments' labels in the EditAppointmentForm, we override the UpdateFormCore
' and edtLabel_EditValueChanged methods in a corresponding EditAppointmentForm
' descendant. The important thing is that a SchedulerStorage instance should
' contain custom appointments' labels in its internal collection. We use the
' SchedulerControl.PopulateLabelsStorage method to replace the collection of
' pre-defined labels with a custom one.
' 
' Note that we are using a custom-made
' DataBindingController class to operate with a label datasource in a generic
' manner. This means that our approach should work correctly regardless of the
' actual datasource type, be it a DataTable or a List<T>.
' Here is a screenshot
' that illustrates meaning of the Appointment.LabelId property (pay attention to
' the CarScheduling.Label and Labels.Id field values):
' 
' Finally, we have
' implemented design-time support for the aforementioned properties:
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E4176

'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.269
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

'#pragma warning disable 1591

Namespace SchedulerMappedLabels


    ''' <summary>
    '''Represents a strongly typed in-memory cache of data.
    '''</summary>
    <Global.System.Serializable(), Global.System.ComponentModel.DesignerCategoryAttribute("code"), Global.System.ComponentModel.ToolboxItem(True), Global.System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema"), Global.System.Xml.Serialization.XmlRootAttribute("CarsDBDataSet"), Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")> _
    Partial Public Class CarsDBDataSet
        Inherits System.Data.DataSet

        Private tableCarScheduling As CarSchedulingDataTable

        Private tableLabels As LabelsDataTable

        Private _schemaSerializationMode As Global.System.Data.SchemaSerializationMode = Global.System.Data.SchemaSerializationMode.IncludeSchema

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Public Sub New()
            Me.BeginInit()
            Me.InitClass()
            Dim schemaChangedHandler As New Global.System.ComponentModel.CollectionChangeEventHandler(AddressOf Me.SchemaChanged)
            AddHandler MyBase.Tables.CollectionChanged, schemaChangedHandler
            AddHandler MyBase.Relations.CollectionChanged, schemaChangedHandler
            Me.EndInit()
        End Sub

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Protected Sub New(ByVal info As Global.System.Runtime.Serialization.SerializationInfo, ByVal context As Global.System.Runtime.Serialization.StreamingContext)
            MyBase.New(info, context, False)
            If (Me.IsBinarySerialized(info, context) = True) Then
                Me.InitVars(False)
                Dim schemaChangedHandler1 As New Global.System.ComponentModel.CollectionChangeEventHandler(AddressOf Me.SchemaChanged)
                AddHandler Me.Tables.CollectionChanged, schemaChangedHandler1
                AddHandler Me.Relations.CollectionChanged, schemaChangedHandler1
                Return
            End If
            Dim strSchema As String = (DirectCast(info.GetValue("XmlSchema", GetType(String)), String))
            If (Me.DetermineSchemaSerializationMode(info, context) = Global.System.Data.SchemaSerializationMode.IncludeSchema) Then
                Dim ds As New Global.System.Data.DataSet()
                ds.ReadXmlSchema(New Global.System.Xml.XmlTextReader(New Global.System.IO.StringReader(strSchema)))
                If (ds.Tables("CarScheduling") IsNot Nothing) Then
                    MyBase.Tables.Add(New CarSchedulingDataTable(ds.Tables("CarScheduling")))
                End If
                If (ds.Tables("Labels") IsNot Nothing) Then
                    MyBase.Tables.Add(New LabelsDataTable(ds.Tables("Labels")))
                End If
                Me.DataSetName = ds.DataSetName
                Me.Prefix = ds.Prefix
                Me.Namespace = ds.Namespace
                Me.Locale = ds.Locale
                Me.CaseSensitive = ds.CaseSensitive
                Me.EnforceConstraints = ds.EnforceConstraints
                Me.Merge(ds, False, Global.System.Data.MissingSchemaAction.Add)
                Me.InitVars()
            Else
                Me.ReadXmlSchema(New Global.System.Xml.XmlTextReader(New Global.System.IO.StringReader(strSchema)))
            End If
            Me.GetSerializationData(info, context)
            Dim schemaChangedHandler As New Global.System.ComponentModel.CollectionChangeEventHandler(AddressOf Me.SchemaChanged)
            AddHandler MyBase.Tables.CollectionChanged, schemaChangedHandler
            AddHandler Me.Relations.CollectionChanged, schemaChangedHandler
        End Sub

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Global.System.ComponentModel.Browsable(False), Global.System.ComponentModel.DesignerSerializationVisibility(Global.System.ComponentModel.DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property CarScheduling() As CarSchedulingDataTable
            Get
                Return Me.tableCarScheduling
            End Get
        End Property

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Global.System.ComponentModel.Browsable(False), Global.System.ComponentModel.DesignerSerializationVisibility(Global.System.ComponentModel.DesignerSerializationVisibility.Content)> _
        Public ReadOnly Property Labels() As LabelsDataTable
            Get
                Return Me.tableLabels
            End Get
        End Property

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Global.System.ComponentModel.BrowsableAttribute(True), Global.System.ComponentModel.DesignerSerializationVisibilityAttribute(Global.System.ComponentModel.DesignerSerializationVisibility.Visible)> _
        Public Overrides Property SchemaSerializationMode() As Global.System.Data.SchemaSerializationMode
            Get
                Return Me._schemaSerializationMode
            End Get
            Set(ByVal value As System.Data.SchemaSerializationMode)
                Me._schemaSerializationMode = value
            End Set
        End Property

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Global.System.ComponentModel.DesignerSerializationVisibilityAttribute(Global.System.ComponentModel.DesignerSerializationVisibility.Hidden)> _
        Public Shadows ReadOnly Property Tables() As Global.System.Data.DataTableCollection
            Get
                Return MyBase.Tables
            End Get
        End Property

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Global.System.ComponentModel.DesignerSerializationVisibilityAttribute(Global.System.ComponentModel.DesignerSerializationVisibility.Hidden)> _
        Public Shadows ReadOnly Property Relations() As Global.System.Data.DataRelationCollection
            Get
                Return MyBase.Relations
            End Get
        End Property

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Protected Overrides Sub InitializeDerivedDataSet()
            Me.BeginInit()
            Me.InitClass()
            Me.EndInit()
        End Sub

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Public Overrides Function Clone() As Global.System.Data.DataSet
            Dim cln As CarsDBDataSet = (DirectCast(MyBase.Clone(), CarsDBDataSet))
            cln.InitVars()
            cln.SchemaSerializationMode = Me.SchemaSerializationMode
            Return cln
        End Function

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Protected Overrides Function ShouldSerializeTables() As Boolean
            Return False
        End Function

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Protected Overrides Function ShouldSerializeRelations() As Boolean
            Return False
        End Function

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Protected Overrides Sub ReadXmlSerializable(ByVal reader As Global.System.Xml.XmlReader)
            If (Me.DetermineSchemaSerializationMode(reader) = Global.System.Data.SchemaSerializationMode.IncludeSchema) Then
                Me.Reset()
                Dim ds As New Global.System.Data.DataSet()
                ds.ReadXml(reader)
                If (ds.Tables("CarScheduling") IsNot Nothing) Then
                    MyBase.Tables.Add(New CarSchedulingDataTable(ds.Tables("CarScheduling")))
                End If
                If (ds.Tables("Labels") IsNot Nothing) Then
                    MyBase.Tables.Add(New LabelsDataTable(ds.Tables("Labels")))
                End If
                Me.DataSetName = ds.DataSetName
                Me.Prefix = ds.Prefix
                Me.Namespace = ds.Namespace
                Me.Locale = ds.Locale
                Me.CaseSensitive = ds.CaseSensitive
                Me.EnforceConstraints = ds.EnforceConstraints
                Me.Merge(ds, False, Global.System.Data.MissingSchemaAction.Add)
                Me.InitVars()
            Else
                Me.ReadXml(reader)
                Me.InitVars()
            End If
        End Sub

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Protected Overrides Function GetSchemaSerializable() As Global.System.Xml.Schema.XmlSchema
            Dim stream As New Global.System.IO.MemoryStream()
            Me.WriteXmlSchema(New Global.System.Xml.XmlTextWriter(stream, Nothing))
            stream.Position = 0
            Return Global.System.Xml.Schema.XmlSchema.Read(New Global.System.Xml.XmlTextReader(stream), Nothing)
        End Function

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Friend Sub InitVars()
            Me.InitVars(True)
        End Sub

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Friend Sub InitVars(ByVal initTable As Boolean)
            Me.tableCarScheduling = (CType(MyBase.Tables("CarScheduling"), CarSchedulingDataTable))
            If (initTable = True) Then
                If (Me.tableCarScheduling IsNot Nothing) Then
                    Me.tableCarScheduling.InitVars()
                End If
            End If
            Me.tableLabels = (CType(MyBase.Tables("Labels"), LabelsDataTable))
            If (initTable = True) Then
                If (Me.tableLabels IsNot Nothing) Then
                    Me.tableLabels.InitVars()
                End If
            End If
        End Sub

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Private Sub InitClass()
            Me.DataSetName = "CarsDBDataSet"
            Me.Prefix = ""
            Me.Namespace = "http://tempuri.org/CarsDBDataSet.xsd"
            Me.EnforceConstraints = True
            Me.SchemaSerializationMode = Global.System.Data.SchemaSerializationMode.IncludeSchema
            Me.tableCarScheduling = New CarSchedulingDataTable()
            MyBase.Tables.Add(Me.tableCarScheduling)
            Me.tableLabels = New LabelsDataTable()
            MyBase.Tables.Add(Me.tableLabels)
        End Sub

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Private Function ShouldSerializeCarScheduling() As Boolean
            Return False
        End Function

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Private Function ShouldSerializeLabels() As Boolean
            Return False
        End Function

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Private Sub SchemaChanged(ByVal sender As Object, ByVal e As Global.System.ComponentModel.CollectionChangeEventArgs)
            If (e.Action = Global.System.ComponentModel.CollectionChangeAction.Remove) Then
                Me.InitVars()
            End If
        End Sub

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Public Shared Function GetTypedDataSetSchema(ByVal xs As Global.System.Xml.Schema.XmlSchemaSet) As Global.System.Xml.Schema.XmlSchemaComplexType
            Dim ds As New CarsDBDataSet()
            Dim type As New Global.System.Xml.Schema.XmlSchemaComplexType()
            Dim sequence As New Global.System.Xml.Schema.XmlSchemaSequence()
            Dim any As New Global.System.Xml.Schema.XmlSchemaAny()
            any.Namespace = ds.Namespace
            sequence.Items.Add(any)
            type.Particle = sequence
            Dim dsSchema As Global.System.Xml.Schema.XmlSchema = ds.GetSchemaSerializable()
            If xs.Contains(dsSchema.TargetNamespace) Then
                Dim s1 As New Global.System.IO.MemoryStream()
                Dim s2 As New Global.System.IO.MemoryStream()
                Try
                    Dim schema As Global.System.Xml.Schema.XmlSchema = Nothing
                    dsSchema.Write(s1)
                    Dim schemas As System.Collections.IEnumerator = xs.Schemas(dsSchema.TargetNamespace).GetEnumerator()
                    Do While schemas.MoveNext()
                        schema = (DirectCast(schemas.Current, Global.System.Xml.Schema.XmlSchema))
                        s2.SetLength(0)
                        schema.Write(s2)
                        If (s1.Length = s2.Length) Then
                            s1.Position = 0
                            s2.Position = 0
                            Do While ((s1.Position <> s1.Length) AndAlso (s1.ReadByte() = s2.ReadByte()))

                            Loop
                            If (s1.Position = s1.Length) Then
                                Return type
                            End If
                        End If
                    Loop
                Finally
                    If (s1 IsNot Nothing) Then
                        s1.Close()
                    End If
                    If (s2 IsNot Nothing) Then
                        s2.Close()
                    End If
                End Try
            End If
            xs.Add(dsSchema)
            Return type
        End Function

        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Public Delegate Sub CarSchedulingRowChangeEventHandler(ByVal sender As Object, ByVal e As CarSchedulingRowChangeEvent)

        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Public Delegate Sub LabelsRowChangeEventHandler(ByVal sender As Object, ByVal e As LabelsRowChangeEvent)

        ''' <summary>
        '''Represents the strongly named DataTable class.
        '''</summary>
        <Global.System.Serializable(), Global.System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedTableSchema")> _
        Partial Public Class CarSchedulingDataTable
            Inherits System.Data.TypedTableBase(Of CarSchedulingRow)

            Private columnID As Global.System.Data.DataColumn

            Private columnSubject As Global.System.Data.DataColumn

            Private columnDescription As Global.System.Data.DataColumn

            Private columnLabel As Global.System.Data.DataColumn

            Private columnStartTime As Global.System.Data.DataColumn

            Private columnEndTime As Global.System.Data.DataColumn

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Sub New()
                Me.TableName = "CarScheduling"
                Me.BeginInit()
                Me.InitClass()
                Me.EndInit()
            End Sub

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Friend Sub New(ByVal table As Global.System.Data.DataTable)
                Me.TableName = table.TableName
                If (table.CaseSensitive <> table.DataSet.CaseSensitive) Then
                    Me.CaseSensitive = table.CaseSensitive
                End If
                If (table.Locale.ToString() <> table.DataSet.Locale.ToString()) Then
                    Me.Locale = table.Locale
                End If
                If (table.Namespace <> table.DataSet.Namespace) Then
                    Me.Namespace = table.Namespace
                End If
                Me.Prefix = table.Prefix
                Me.MinimumCapacity = table.MinimumCapacity
            End Sub

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Protected Sub New(ByVal info As Global.System.Runtime.Serialization.SerializationInfo, ByVal context As Global.System.Runtime.Serialization.StreamingContext)
                MyBase.New(info, context)
                Me.InitVars()
            End Sub

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public ReadOnly Property IDColumn() As Global.System.Data.DataColumn
                Get
                    Return Me.columnID
                End Get
            End Property

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public ReadOnly Property SubjectColumn() As Global.System.Data.DataColumn
                Get
                    Return Me.columnSubject
                End Get
            End Property

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public ReadOnly Property DescriptionColumn() As Global.System.Data.DataColumn
                Get
                    Return Me.columnDescription
                End Get
            End Property

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public ReadOnly Property LabelColumn() As Global.System.Data.DataColumn
                Get
                    Return Me.columnLabel
                End Get
            End Property

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public ReadOnly Property StartTimeColumn() As Global.System.Data.DataColumn
                Get
                    Return Me.columnStartTime
                End Get
            End Property

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public ReadOnly Property EndTimeColumn() As Global.System.Data.DataColumn
                Get
                    Return Me.columnEndTime
                End Get
            End Property

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Global.System.ComponentModel.Browsable(False)> _
            Public ReadOnly Property Count() As Integer
                Get
                    Return Me.Rows.Count
                End Get
            End Property

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Default Public ReadOnly Property Item(ByVal index As Integer) As CarSchedulingRow
                Get
                    Return (DirectCast(Me.Rows(index), CarSchedulingRow))
                End Get
            End Property

            <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Event CarSchedulingRowChanging As CarSchedulingRowChangeEventHandler

            <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Event CarSchedulingRowChanged As CarSchedulingRowChangeEventHandler

            <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Event CarSchedulingRowDeleting As CarSchedulingRowChangeEventHandler

            <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Event CarSchedulingRowDeleted As CarSchedulingRowChangeEventHandler

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Sub AddCarSchedulingRow(ByVal row As CarSchedulingRow)
                Me.Rows.Add(row)
            End Sub

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Function AddCarSchedulingRow(ByVal Subject As String, ByVal Description As String, ByVal Label As Integer, ByVal StartTime As Date, ByVal EndTime As Date) As CarSchedulingRow
                Dim rowCarSchedulingRow As CarSchedulingRow = (DirectCast(Me.NewRow(), CarSchedulingRow))
                Dim columnValuesArray() As Object = { Nothing, Subject, Description, Label, StartTime, EndTime}
                rowCarSchedulingRow.ItemArray = columnValuesArray
                Me.Rows.Add(rowCarSchedulingRow)
                Return rowCarSchedulingRow
            End Function

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Function FindByID(ByVal ID As Integer) As CarSchedulingRow
                Return (DirectCast(Me.Rows.Find(New Object() { ID}), CarSchedulingRow))
            End Function

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Overrides Function Clone() As Global.System.Data.DataTable
                Dim cln As CarSchedulingDataTable = (DirectCast(MyBase.Clone(), CarSchedulingDataTable))
                cln.InitVars()
                Return cln
            End Function

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Protected Overrides Function CreateInstance() As Global.System.Data.DataTable
                Return New CarSchedulingDataTable()
            End Function

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Friend Sub InitVars()
                Me.columnID = MyBase.Columns("ID")
                Me.columnSubject = MyBase.Columns("Subject")
                Me.columnDescription = MyBase.Columns("Description")
                Me.columnLabel = MyBase.Columns("Label")
                Me.columnStartTime = MyBase.Columns("StartTime")
                Me.columnEndTime = MyBase.Columns("EndTime")
            End Sub

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Private Sub InitClass()
                Me.columnID = New Global.System.Data.DataColumn("ID", GetType(Integer), Nothing, Global.System.Data.MappingType.Element)
                MyBase.Columns.Add(Me.columnID)
                Me.columnSubject = New Global.System.Data.DataColumn("Subject", GetType(String), Nothing, Global.System.Data.MappingType.Element)
                MyBase.Columns.Add(Me.columnSubject)
                Me.columnDescription = New Global.System.Data.DataColumn("Description", GetType(String), Nothing, Global.System.Data.MappingType.Element)
                MyBase.Columns.Add(Me.columnDescription)
                Me.columnLabel = New Global.System.Data.DataColumn("Label", GetType(Integer), Nothing, Global.System.Data.MappingType.Element)
                MyBase.Columns.Add(Me.columnLabel)
                Me.columnStartTime = New Global.System.Data.DataColumn("StartTime", GetType(Date), Nothing, Global.System.Data.MappingType.Element)
                MyBase.Columns.Add(Me.columnStartTime)
                Me.columnEndTime = New Global.System.Data.DataColumn("EndTime", GetType(Date), Nothing, Global.System.Data.MappingType.Element)
                MyBase.Columns.Add(Me.columnEndTime)
                Me.Constraints.Add(New Global.System.Data.UniqueConstraint("Constraint1", New Global.System.Data.DataColumn() { Me.columnID}, True))
                Me.columnID.AutoIncrement = True
                Me.columnID.AllowDBNull = False
                Me.columnID.Unique = True
                Me.columnSubject.MaxLength = 50
                Me.columnDescription.MaxLength = 536870910
            End Sub

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Function NewCarSchedulingRow() As CarSchedulingRow
                Return (DirectCast(Me.NewRow(), CarSchedulingRow))
            End Function

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Protected Overrides Function NewRowFromBuilder(ByVal builder As Global.System.Data.DataRowBuilder) As Global.System.Data.DataRow
                Return New CarSchedulingRow(builder)
            End Function

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Protected Overrides Function GetRowType() As Global.System.Type
                Return GetType(CarSchedulingRow)
            End Function

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Protected Overrides Sub OnRowChanged(ByVal e As Global.System.Data.DataRowChangeEventArgs)
                MyBase.OnRowChanged(e)
                RaiseEvent CarSchedulingRowChanged(Me, New CarSchedulingRowChangeEvent((DirectCast(e.Row, CarSchedulingRow)), e.Action))
            End Sub

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Protected Overrides Sub OnRowChanging(ByVal e As Global.System.Data.DataRowChangeEventArgs)
                MyBase.OnRowChanging(e)
                RaiseEvent CarSchedulingRowChanging(Me, New CarSchedulingRowChangeEvent((DirectCast(e.Row, CarSchedulingRow)), e.Action))
            End Sub

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Protected Overrides Sub OnRowDeleted(ByVal e As Global.System.Data.DataRowChangeEventArgs)
                MyBase.OnRowDeleted(e)
                RaiseEvent CarSchedulingRowDeleted(Me, New CarSchedulingRowChangeEvent((DirectCast(e.Row, CarSchedulingRow)), e.Action))
            End Sub

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Protected Overrides Sub OnRowDeleting(ByVal e As Global.System.Data.DataRowChangeEventArgs)
                MyBase.OnRowDeleting(e)
                RaiseEvent CarSchedulingRowDeleting(Me, New CarSchedulingRowChangeEvent((DirectCast(e.Row, CarSchedulingRow)), e.Action))
            End Sub

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Sub RemoveCarSchedulingRow(ByVal row As CarSchedulingRow)
                Me.Rows.Remove(row)
            End Sub

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Shared Function GetTypedTableSchema(ByVal xs As Global.System.Xml.Schema.XmlSchemaSet) As Global.System.Xml.Schema.XmlSchemaComplexType
                Dim type As New Global.System.Xml.Schema.XmlSchemaComplexType()
                Dim sequence As New Global.System.Xml.Schema.XmlSchemaSequence()
                Dim ds As New CarsDBDataSet()
                Dim any1 As New Global.System.Xml.Schema.XmlSchemaAny()
                any1.Namespace = "http://www.w3.org/2001/XMLSchema"
                any1.MinOccurs = New Decimal(0)
                any1.MaxOccurs = Decimal.MaxValue
                any1.ProcessContents = Global.System.Xml.Schema.XmlSchemaContentProcessing.Lax
                sequence.Items.Add(any1)
                Dim any2 As New Global.System.Xml.Schema.XmlSchemaAny()
                any2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1"
                any2.MinOccurs = New Decimal(1)
                any2.ProcessContents = Global.System.Xml.Schema.XmlSchemaContentProcessing.Lax
                sequence.Items.Add(any2)
                Dim attribute1 As New Global.System.Xml.Schema.XmlSchemaAttribute()
                attribute1.Name = "namespace"
                attribute1.FixedValue = ds.Namespace
                type.Attributes.Add(attribute1)
                Dim attribute2 As New Global.System.Xml.Schema.XmlSchemaAttribute()
                attribute2.Name = "tableTypeName"
                attribute2.FixedValue = "CarSchedulingDataTable"
                type.Attributes.Add(attribute2)
                type.Particle = sequence
                Dim dsSchema As Global.System.Xml.Schema.XmlSchema = ds.GetSchemaSerializable()
                If xs.Contains(dsSchema.TargetNamespace) Then
                    Dim s1 As New Global.System.IO.MemoryStream()
                    Dim s2 As New Global.System.IO.MemoryStream()
                    Try
                        Dim schema As Global.System.Xml.Schema.XmlSchema = Nothing
                        dsSchema.Write(s1)
                        Dim schemas As System.Collections.IEnumerator = xs.Schemas(dsSchema.TargetNamespace).GetEnumerator()
                        Do While schemas.MoveNext()
                            schema = (DirectCast(schemas.Current, Global.System.Xml.Schema.XmlSchema))
                            s2.SetLength(0)
                            schema.Write(s2)
                            If (s1.Length = s2.Length) Then
                                s1.Position = 0
                                s2.Position = 0
                                Do While ((s1.Position <> s1.Length) AndAlso (s1.ReadByte() = s2.ReadByte()))

                                Loop
                                If (s1.Position = s1.Length) Then
                                    Return type
                                End If
                            End If
                        Loop
                    Finally
                        If (s1 IsNot Nothing) Then
                            s1.Close()
                        End If
                        If (s2 IsNot Nothing) Then
                            s2.Close()
                        End If
                    End Try
                End If
                xs.Add(dsSchema)
                Return type
            End Function
        End Class

        ''' <summary>
        '''Represents the strongly named DataTable class.
        '''</summary>
        <Global.System.Serializable(), Global.System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedTableSchema")> _
        Partial Public Class LabelsDataTable
            Inherits System.Data.TypedTableBase(Of LabelsRow)

            Private columnID As Global.System.Data.DataColumn

            Private columnColor As Global.System.Data.DataColumn

            Private columnDisplayName As Global.System.Data.DataColumn

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Sub New()
                Me.TableName = "Labels"
                Me.BeginInit()
                Me.InitClass()
                Me.EndInit()
            End Sub

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Friend Sub New(ByVal table As Global.System.Data.DataTable)
                Me.TableName = table.TableName
                If (table.CaseSensitive <> table.DataSet.CaseSensitive) Then
                    Me.CaseSensitive = table.CaseSensitive
                End If
                If (table.Locale.ToString() <> table.DataSet.Locale.ToString()) Then
                    Me.Locale = table.Locale
                End If
                If (table.Namespace <> table.DataSet.Namespace) Then
                    Me.Namespace = table.Namespace
                End If
                Me.Prefix = table.Prefix
                Me.MinimumCapacity = table.MinimumCapacity
            End Sub

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Protected Sub New(ByVal info As Global.System.Runtime.Serialization.SerializationInfo, ByVal context As Global.System.Runtime.Serialization.StreamingContext)
                MyBase.New(info, context)
                Me.InitVars()
            End Sub

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public ReadOnly Property IDColumn() As Global.System.Data.DataColumn
                Get
                    Return Me.columnID
                End Get
            End Property

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public ReadOnly Property ColorColumn() As Global.System.Data.DataColumn
                Get
                    Return Me.columnColor
                End Get
            End Property

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public ReadOnly Property DisplayNameColumn() As Global.System.Data.DataColumn
                Get
                    Return Me.columnDisplayName
                End Get
            End Property

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Global.System.ComponentModel.Browsable(False)> _
            Public ReadOnly Property Count() As Integer
                Get
                    Return Me.Rows.Count
                End Get
            End Property

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Default Public ReadOnly Property Item(ByVal index As Integer) As LabelsRow
                Get
                    Return (DirectCast(Me.Rows(index), LabelsRow))
                End Get
            End Property

            <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Event LabelsRowChanging As LabelsRowChangeEventHandler

            <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Event LabelsRowChanged As LabelsRowChangeEventHandler

            <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Event LabelsRowDeleting As LabelsRowChangeEventHandler

            <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Event LabelsRowDeleted As LabelsRowChangeEventHandler

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Sub AddLabelsRow(ByVal row As LabelsRow)
                Me.Rows.Add(row)
            End Sub

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Function AddLabelsRow(ByVal ID As Integer, ByVal Color As Integer, ByVal DisplayName As String) As LabelsRow
                Dim rowLabelsRow As LabelsRow = (DirectCast(Me.NewRow(), LabelsRow))
                Dim columnValuesArray() As Object = { ID, Color, DisplayName}
                rowLabelsRow.ItemArray = columnValuesArray
                Me.Rows.Add(rowLabelsRow)
                Return rowLabelsRow
            End Function

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Function FindByID(ByVal ID As Integer) As LabelsRow
                Return (DirectCast(Me.Rows.Find(New Object() { ID}), LabelsRow))
            End Function

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Overrides Function Clone() As Global.System.Data.DataTable
                Dim cln As LabelsDataTable = (DirectCast(MyBase.Clone(), LabelsDataTable))
                cln.InitVars()
                Return cln
            End Function

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Protected Overrides Function CreateInstance() As Global.System.Data.DataTable
                Return New LabelsDataTable()
            End Function

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Friend Sub InitVars()
                Me.columnID = MyBase.Columns("ID")
                Me.columnColor = MyBase.Columns("Color")
                Me.columnDisplayName = MyBase.Columns("DisplayName")
            End Sub

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Private Sub InitClass()
                Me.columnID = New Global.System.Data.DataColumn("ID", GetType(Integer), Nothing, Global.System.Data.MappingType.Element)
                MyBase.Columns.Add(Me.columnID)
                Me.columnColor = New Global.System.Data.DataColumn("Color", GetType(Integer), Nothing, Global.System.Data.MappingType.Element)
                MyBase.Columns.Add(Me.columnColor)
                Me.columnDisplayName = New Global.System.Data.DataColumn("DisplayName", GetType(String), Nothing, Global.System.Data.MappingType.Element)
                MyBase.Columns.Add(Me.columnDisplayName)
                Me.Constraints.Add(New Global.System.Data.UniqueConstraint("Constraint1", New Global.System.Data.DataColumn() { Me.columnID}, True))
                Me.columnID.AllowDBNull = False
                Me.columnID.Unique = True
                Me.columnDisplayName.MaxLength = 50
            End Sub

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Function NewLabelsRow() As LabelsRow
                Return (DirectCast(Me.NewRow(), LabelsRow))
            End Function

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Protected Overrides Function NewRowFromBuilder(ByVal builder As Global.System.Data.DataRowBuilder) As Global.System.Data.DataRow
                Return New LabelsRow(builder)
            End Function

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Protected Overrides Function GetRowType() As Global.System.Type
                Return GetType(LabelsRow)
            End Function

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Protected Overrides Sub OnRowChanged(ByVal e As Global.System.Data.DataRowChangeEventArgs)
                MyBase.OnRowChanged(e)
                RaiseEvent LabelsRowChanged(Me, New LabelsRowChangeEvent((DirectCast(e.Row, LabelsRow)), e.Action))
            End Sub

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Protected Overrides Sub OnRowChanging(ByVal e As Global.System.Data.DataRowChangeEventArgs)
                MyBase.OnRowChanging(e)
                RaiseEvent LabelsRowChanging(Me, New LabelsRowChangeEvent((DirectCast(e.Row, LabelsRow)), e.Action))
            End Sub

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Protected Overrides Sub OnRowDeleted(ByVal e As Global.System.Data.DataRowChangeEventArgs)
                MyBase.OnRowDeleted(e)
                RaiseEvent LabelsRowDeleted(Me, New LabelsRowChangeEvent((DirectCast(e.Row, LabelsRow)), e.Action))
            End Sub

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Protected Overrides Sub OnRowDeleting(ByVal e As Global.System.Data.DataRowChangeEventArgs)
                MyBase.OnRowDeleting(e)
                RaiseEvent LabelsRowDeleting(Me, New LabelsRowChangeEvent((DirectCast(e.Row, LabelsRow)), e.Action))
            End Sub

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Sub RemoveLabelsRow(ByVal row As LabelsRow)
                Me.Rows.Remove(row)
            End Sub

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Shared Function GetTypedTableSchema(ByVal xs As Global.System.Xml.Schema.XmlSchemaSet) As Global.System.Xml.Schema.XmlSchemaComplexType
                Dim type As New Global.System.Xml.Schema.XmlSchemaComplexType()
                Dim sequence As New Global.System.Xml.Schema.XmlSchemaSequence()
                Dim ds As New CarsDBDataSet()
                Dim any1 As New Global.System.Xml.Schema.XmlSchemaAny()
                any1.Namespace = "http://www.w3.org/2001/XMLSchema"
                any1.MinOccurs = New Decimal(0)
                any1.MaxOccurs = Decimal.MaxValue
                any1.ProcessContents = Global.System.Xml.Schema.XmlSchemaContentProcessing.Lax
                sequence.Items.Add(any1)
                Dim any2 As New Global.System.Xml.Schema.XmlSchemaAny()
                any2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1"
                any2.MinOccurs = New Decimal(1)
                any2.ProcessContents = Global.System.Xml.Schema.XmlSchemaContentProcessing.Lax
                sequence.Items.Add(any2)
                Dim attribute1 As New Global.System.Xml.Schema.XmlSchemaAttribute()
                attribute1.Name = "namespace"
                attribute1.FixedValue = ds.Namespace
                type.Attributes.Add(attribute1)
                Dim attribute2 As New Global.System.Xml.Schema.XmlSchemaAttribute()
                attribute2.Name = "tableTypeName"
                attribute2.FixedValue = "LabelsDataTable"
                type.Attributes.Add(attribute2)
                type.Particle = sequence
                Dim dsSchema As Global.System.Xml.Schema.XmlSchema = ds.GetSchemaSerializable()
                If xs.Contains(dsSchema.TargetNamespace) Then
                    Dim s1 As New Global.System.IO.MemoryStream()
                    Dim s2 As New Global.System.IO.MemoryStream()
                    Try
                        Dim schema As Global.System.Xml.Schema.XmlSchema = Nothing
                        dsSchema.Write(s1)
                        Dim schemas As System.Collections.IEnumerator = xs.Schemas(dsSchema.TargetNamespace).GetEnumerator()
                        Do While schemas.MoveNext()
                            schema = (DirectCast(schemas.Current, Global.System.Xml.Schema.XmlSchema))
                            s2.SetLength(0)
                            schema.Write(s2)
                            If (s1.Length = s2.Length) Then
                                s1.Position = 0
                                s2.Position = 0
                                Do While ((s1.Position <> s1.Length) AndAlso (s1.ReadByte() = s2.ReadByte()))

                                Loop
                                If (s1.Position = s1.Length) Then
                                    Return type
                                End If
                            End If
                        Loop
                    Finally
                        If (s1 IsNot Nothing) Then
                            s1.Close()
                        End If
                        If (s2 IsNot Nothing) Then
                            s2.Close()
                        End If
                    End Try
                End If
                xs.Add(dsSchema)
                Return type
            End Function
        End Class

        ''' <summary>
        '''Represents strongly named DataRow class.
        '''</summary>
        Partial Public Class CarSchedulingRow
            Inherits System.Data.DataRow

            Private tableCarScheduling As CarSchedulingDataTable

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Friend Sub New(ByVal rb As Global.System.Data.DataRowBuilder)
                MyBase.New(rb)
                Me.tableCarScheduling = (CType(Me.Table, CarSchedulingDataTable))
            End Sub

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Property ID() As Integer
                Get
                    Return (DirectCast(Me(Me.tableCarScheduling.IDColumn), Integer))
                End Get
                Set(ByVal value As Integer)
                    Me(Me.tableCarScheduling.IDColumn) = value
                End Set
            End Property

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Property Subject() As String
                Get
                    Try
                        Return (DirectCast(Me(Me.tableCarScheduling.SubjectColumn), String))
                    Catch e As Global.System.InvalidCastException
                        Throw New Global.System.Data.StrongTypingException("The value for column 'Subject' in table 'CarScheduling' is DBNull.", e)
                    End Try
                End Get
                Set(ByVal value As String)
                    Me(Me.tableCarScheduling.SubjectColumn) = value
                End Set
            End Property

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Property Description() As String
                Get
                    Try
                        Return (DirectCast(Me(Me.tableCarScheduling.DescriptionColumn), String))
                    Catch e As Global.System.InvalidCastException
                        Throw New Global.System.Data.StrongTypingException("The value for column 'Description' in table 'CarScheduling' is DBNull.", e)
                    End Try
                End Get
                Set(ByVal value As String)
                    Me(Me.tableCarScheduling.DescriptionColumn) = value
                End Set
            End Property

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Property Label() As Integer
                Get
                    Try
                        Return (DirectCast(Me(Me.tableCarScheduling.LabelColumn), Integer))
                    Catch e As Global.System.InvalidCastException
                        Throw New Global.System.Data.StrongTypingException("The value for column 'Label' in table 'CarScheduling' is DBNull.", e)
                    End Try
                End Get
                Set(ByVal value As Integer)
                    Me(Me.tableCarScheduling.LabelColumn) = value
                End Set
            End Property

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Property StartTime() As Date
                Get
                    Try
                        Return (DirectCast(Me(Me.tableCarScheduling.StartTimeColumn), Global.System.DateTime))
                    Catch e As Global.System.InvalidCastException
                        Throw New Global.System.Data.StrongTypingException("The value for column 'StartTime' in table 'CarScheduling' is DBNull.", e)
                    End Try
                End Get
                Set(ByVal value As Date)
                    Me(Me.tableCarScheduling.StartTimeColumn) = value
                End Set
            End Property

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Property EndTime() As Date
                Get
                    Try
                        Return (DirectCast(Me(Me.tableCarScheduling.EndTimeColumn), Global.System.DateTime))
                    Catch e As Global.System.InvalidCastException
                        Throw New Global.System.Data.StrongTypingException("The value for column 'EndTime' in table 'CarScheduling' is DBNull.", e)
                    End Try
                End Get
                Set(ByVal value As Date)
                    Me(Me.tableCarScheduling.EndTimeColumn) = value
                End Set
            End Property

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Function IsSubjectNull() As Boolean
                Return Me.IsNull(Me.tableCarScheduling.SubjectColumn)
            End Function

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Sub SetSubjectNull()
                Me(Me.tableCarScheduling.SubjectColumn) = Global.System.Convert.DBNull
            End Sub

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Function IsDescriptionNull() As Boolean
                Return Me.IsNull(Me.tableCarScheduling.DescriptionColumn)
            End Function

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Sub SetDescriptionNull()
                Me(Me.tableCarScheduling.DescriptionColumn) = Global.System.Convert.DBNull
            End Sub

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Function IsLabelNull() As Boolean
                Return Me.IsNull(Me.tableCarScheduling.LabelColumn)
            End Function

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Sub SetLabelNull()
                Me(Me.tableCarScheduling.LabelColumn) = Global.System.Convert.DBNull
            End Sub

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Function IsStartTimeNull() As Boolean
                Return Me.IsNull(Me.tableCarScheduling.StartTimeColumn)
            End Function

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Sub SetStartTimeNull()
                Me(Me.tableCarScheduling.StartTimeColumn) = Global.System.Convert.DBNull
            End Sub

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Function IsEndTimeNull() As Boolean
                Return Me.IsNull(Me.tableCarScheduling.EndTimeColumn)
            End Function

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Sub SetEndTimeNull()
                Me(Me.tableCarScheduling.EndTimeColumn) = Global.System.Convert.DBNull
            End Sub
        End Class

        ''' <summary>
        '''Represents strongly named DataRow class.
        '''</summary>
        Partial Public Class LabelsRow
            Inherits System.Data.DataRow

            Private tableLabels As LabelsDataTable

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Friend Sub New(ByVal rb As Global.System.Data.DataRowBuilder)
                MyBase.New(rb)
                Me.tableLabels = (CType(Me.Table, LabelsDataTable))
            End Sub

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Property ID() As Integer
                Get
                    Return (DirectCast(Me(Me.tableLabels.IDColumn), Integer))
                End Get
                Set(ByVal value As Integer)
                    Me(Me.tableLabels.IDColumn) = value
                End Set
            End Property

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Property Color() As Integer
                Get
                    Try
                        Return (DirectCast(Me(Me.tableLabels.ColorColumn), Integer))
                    Catch e As Global.System.InvalidCastException
                        Throw New Global.System.Data.StrongTypingException("The value for column 'Color' in table 'Labels' is DBNull.", e)
                    End Try
                End Get
                Set(ByVal value As Integer)
                    Me(Me.tableLabels.ColorColumn) = value
                End Set
            End Property

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Property DisplayName() As String
                Get
                    Try
                        Return (DirectCast(Me(Me.tableLabels.DisplayNameColumn), String))
                    Catch e As Global.System.InvalidCastException
                        Throw New Global.System.Data.StrongTypingException("The value for column 'DisplayName' in table 'Labels' is DBNull.", e)
                    End Try
                End Get
                Set(ByVal value As String)
                    Me(Me.tableLabels.DisplayNameColumn) = value
                End Set
            End Property

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Function IsColorNull() As Boolean
                Return Me.IsNull(Me.tableLabels.ColorColumn)
            End Function

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Sub SetColorNull()
                Me(Me.tableLabels.ColorColumn) = Global.System.Convert.DBNull
            End Sub

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Function IsDisplayNameNull() As Boolean
                Return Me.IsNull(Me.tableLabels.DisplayNameColumn)
            End Function

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Sub SetDisplayNameNull()
                Me(Me.tableLabels.DisplayNameColumn) = Global.System.Convert.DBNull
            End Sub
        End Class

        ''' <summary>
        '''Row event argument class
        '''</summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Public Class CarSchedulingRowChangeEvent
            Inherits System.EventArgs

            Private eventRow As CarSchedulingRow

            Private eventAction As Global.System.Data.DataRowAction

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Sub New(ByVal row As CarSchedulingRow, ByVal action As Global.System.Data.DataRowAction)
                Me.eventRow = row
                Me.eventAction = action
            End Sub

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public ReadOnly Property Row() As CarSchedulingRow
                Get
                    Return Me.eventRow
                End Get
            End Property

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public ReadOnly Property Action() As Global.System.Data.DataRowAction
                Get
                    Return Me.eventAction
                End Get
            End Property
        End Class

        ''' <summary>
        '''Row event argument class
        '''</summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Public Class LabelsRowChangeEvent
            Inherits System.EventArgs

            Private eventRow As LabelsRow

            Private eventAction As Global.System.Data.DataRowAction

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Sub New(ByVal row As LabelsRow, ByVal action As Global.System.Data.DataRowAction)
                Me.eventRow = row
                Me.eventAction = action
            End Sub

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public ReadOnly Property Row() As LabelsRow
                Get
                    Return Me.eventRow
                End Get
            End Property

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public ReadOnly Property Action() As Global.System.Data.DataRowAction
                Get
                    Return Me.eventAction
                End Get
            End Property
        End Class
    End Class
End Namespace
Namespace SchedulerMappedLabels.CarsDBDataSetTableAdapters


    ''' <summary>
    '''Represents the connection and commands used to retrieve and save data.
    '''</summary>
    <Global.System.ComponentModel.DesignerCategoryAttribute("code"), Global.System.ComponentModel.ToolboxItem(True), Global.System.ComponentModel.DataObjectAttribute(True), Global.System.ComponentModel.DesignerAttribute("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner" & ", Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")> _
    Partial Public Class CarSchedulingTableAdapter
        Inherits System.ComponentModel.Component

        Private _adapter As Global.System.Data.OleDb.OleDbDataAdapter

        Private _connection As Global.System.Data.OleDb.OleDbConnection

        Private _transaction As Global.System.Data.OleDb.OleDbTransaction

        Private _commandCollection() As Global.System.Data.OleDb.OleDbCommand

        Private _clearBeforeFill As Boolean

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Public Sub New()
            Me.ClearBeforeFill = True
        End Sub

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Protected Friend ReadOnly Property Adapter() As Global.System.Data.OleDb.OleDbDataAdapter
            Get
                If (Me._adapter Is Nothing) Then
                    Me.InitAdapter()
                End If
                Return Me._adapter
            End Get
        End Property

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Friend Property Connection() As Global.System.Data.OleDb.OleDbConnection
            Get
                If (Me._connection Is Nothing) Then
                    Me.InitConnection()
                End If
                Return Me._connection
            End Get
            Set(ByVal value As System.Data.OleDb.OleDbConnection)
                Me._connection = value
                If (Me.Adapter.InsertCommand IsNot Nothing) Then
                    Me.Adapter.InsertCommand.Connection = value
                End If
                If (Me.Adapter.DeleteCommand IsNot Nothing) Then
                    Me.Adapter.DeleteCommand.Connection = value
                End If
                If (Me.Adapter.UpdateCommand IsNot Nothing) Then
                    Me.Adapter.UpdateCommand.Connection = value
                End If
                Dim i As Integer = 0
                Do While (i < Me.CommandCollection.Length)
                    If (Me.CommandCollection(i) IsNot Nothing) Then
                        CType(Me.CommandCollection(i), Global.System.Data.OleDb.OleDbCommand).Connection = value
                    End If
                    i = (i + 1)
                Loop
            End Set
        End Property

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Friend Property Transaction() As Global.System.Data.OleDb.OleDbTransaction
            Get
                Return Me._transaction
            End Get
            Set(ByVal value As System.Data.OleDb.OleDbTransaction)
                Me._transaction = value
                Dim i As Integer = 0
                Do While (i < Me.CommandCollection.Length)
                    Me.CommandCollection(i).Transaction = Me._transaction
                    i = (i + 1)
                Loop
                If ((Me.Adapter IsNot Nothing) AndAlso (Me.Adapter.DeleteCommand IsNot Nothing)) Then
                    Me.Adapter.DeleteCommand.Transaction = Me._transaction
                End If
                If ((Me.Adapter IsNot Nothing) AndAlso (Me.Adapter.InsertCommand IsNot Nothing)) Then
                    Me.Adapter.InsertCommand.Transaction = Me._transaction
                End If
                If ((Me.Adapter IsNot Nothing) AndAlso (Me.Adapter.UpdateCommand IsNot Nothing)) Then
                    Me.Adapter.UpdateCommand.Transaction = Me._transaction
                End If
            End Set
        End Property

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Protected ReadOnly Property CommandCollection() As Global.System.Data.OleDb.OleDbCommand()
            Get
                If (Me._commandCollection Is Nothing) Then
                    Me.InitCommandCollection()
                End If
                Return Me._commandCollection
            End Get
        End Property

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Public Property ClearBeforeFill() As Boolean
            Get
                Return Me._clearBeforeFill
            End Get
            Set(ByVal value As Boolean)
                Me._clearBeforeFill = value
            End Set
        End Property

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Private Sub InitAdapter()
            Me._adapter = New Global.System.Data.OleDb.OleDbDataAdapter()
            Dim tableMapping As New Global.System.Data.Common.DataTableMapping()
            tableMapping.SourceTable = "Table"
            tableMapping.DataSetTable = "CarScheduling"
            tableMapping.ColumnMappings.Add("ID", "ID")
            tableMapping.ColumnMappings.Add("Subject", "Subject")
            tableMapping.ColumnMappings.Add("Description", "Description")
            tableMapping.ColumnMappings.Add("Label", "Label")
            tableMapping.ColumnMappings.Add("StartTime", "StartTime")
            tableMapping.ColumnMappings.Add("EndTime", "EndTime")
            Me._adapter.TableMappings.Add(tableMapping)
            Me._adapter.DeleteCommand = New Global.System.Data.OleDb.OleDbCommand()
            Me._adapter.DeleteCommand.Connection = Me.Connection
            Me._adapter.DeleteCommand.CommandText = "DELETE FROM `CarScheduling` WHERE ((`ID` = ?) AND ((? = 1 AND `Subject` IS NULL) OR (`Subject` = ?)) AND ((? = 1 AND `Label` IS NULL) OR (`Label` = ?)) AND ((? = 1 AND `StartTime` IS NULL) OR (`StartTime` = ?)) AND ((? = 1 AND `EndTime` IS NULL) OR (`EndTime` = ?)))"
            Me._adapter.DeleteCommand.CommandType = Global.System.Data.CommandType.Text
            Me._adapter.DeleteCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("Original_ID", Global.System.Data.OleDb.OleDbType.Integer, 0, Global.System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "ID", Global.System.Data.DataRowVersion.Original, False, Nothing))
            Me._adapter.DeleteCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("IsNull_Subject", Global.System.Data.OleDb.OleDbType.Integer, 0, Global.System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "Subject", Global.System.Data.DataRowVersion.Original, True, Nothing))
            Me._adapter.DeleteCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("Original_Subject", Global.System.Data.OleDb.OleDbType.VarWChar, 0, Global.System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "Subject", Global.System.Data.DataRowVersion.Original, False, Nothing))
            Me._adapter.DeleteCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("IsNull_Label", Global.System.Data.OleDb.OleDbType.Integer, 0, Global.System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "Label", Global.System.Data.DataRowVersion.Original, True, Nothing))
            Me._adapter.DeleteCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("Original_Label", Global.System.Data.OleDb.OleDbType.Integer, 0, Global.System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "Label", Global.System.Data.DataRowVersion.Original, False, Nothing))
            Me._adapter.DeleteCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("IsNull_StartTime", Global.System.Data.OleDb.OleDbType.Integer, 0, Global.System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "StartTime", Global.System.Data.DataRowVersion.Original, True, Nothing))
            Me._adapter.DeleteCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("Original_StartTime", Global.System.Data.OleDb.OleDbType.Date, 0, Global.System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "StartTime", Global.System.Data.DataRowVersion.Original, False, Nothing))
            Me._adapter.DeleteCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("IsNull_EndTime", Global.System.Data.OleDb.OleDbType.Integer, 0, Global.System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "EndTime", Global.System.Data.DataRowVersion.Original, True, Nothing))
            Me._adapter.DeleteCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("Original_EndTime", Global.System.Data.OleDb.OleDbType.Date, 0, Global.System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "EndTime", Global.System.Data.DataRowVersion.Original, False, Nothing))
            Me._adapter.InsertCommand = New Global.System.Data.OleDb.OleDbCommand()
            Me._adapter.InsertCommand.Connection = Me.Connection
            Me._adapter.InsertCommand.CommandText = "INSERT INTO `CarScheduling` (`Subject`, `Description`, `Label`, `StartTime`, `End" & "Time`) VALUES (?, ?, ?, ?, ?)"
            Me._adapter.InsertCommand.CommandType = Global.System.Data.CommandType.Text
            Me._adapter.InsertCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("Subject", Global.System.Data.OleDb.OleDbType.VarWChar, 0, Global.System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "Subject", Global.System.Data.DataRowVersion.Current, False, Nothing))
            Me._adapter.InsertCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("Description", Global.System.Data.OleDb.OleDbType.LongVarWChar, 0, Global.System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "Description", Global.System.Data.DataRowVersion.Current, False, Nothing))
            Me._adapter.InsertCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("Label", Global.System.Data.OleDb.OleDbType.Integer, 0, Global.System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "Label", Global.System.Data.DataRowVersion.Current, False, Nothing))
            Me._adapter.InsertCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("StartTime", Global.System.Data.OleDb.OleDbType.Date, 0, Global.System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "StartTime", Global.System.Data.DataRowVersion.Current, False, Nothing))
            Me._adapter.InsertCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("EndTime", Global.System.Data.OleDb.OleDbType.Date, 0, Global.System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "EndTime", Global.System.Data.DataRowVersion.Current, False, Nothing))
            Me._adapter.UpdateCommand = New Global.System.Data.OleDb.OleDbCommand()
            Me._adapter.UpdateCommand.Connection = Me.Connection
            Me._adapter.UpdateCommand.CommandText = "UPDATE `CarScheduling` SET `Subject` = ?, `Description` = ?, `Label` = ?, `StartTime` = ?, `EndTime` = ? WHERE ((`ID` = ?) AND ((? = 1 AND `Subject` IS NULL) OR (`Subject` = ?)) AND ((? = 1 AND `Label` IS NULL) OR (`Label` = ?)) AND ((? = 1 AND `StartTime` IS NULL) OR (`StartTime` = ?)) AND ((? = 1 AND `EndTime` IS NULL) OR (`EndTime` = ?)))"
            Me._adapter.UpdateCommand.CommandType = Global.System.Data.CommandType.Text
            Me._adapter.UpdateCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("Subject", Global.System.Data.OleDb.OleDbType.VarWChar, 0, Global.System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "Subject", Global.System.Data.DataRowVersion.Current, False, Nothing))
            Me._adapter.UpdateCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("Description", Global.System.Data.OleDb.OleDbType.LongVarWChar, 0, Global.System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "Description", Global.System.Data.DataRowVersion.Current, False, Nothing))
            Me._adapter.UpdateCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("Label", Global.System.Data.OleDb.OleDbType.Integer, 0, Global.System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "Label", Global.System.Data.DataRowVersion.Current, False, Nothing))
            Me._adapter.UpdateCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("StartTime", Global.System.Data.OleDb.OleDbType.Date, 0, Global.System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "StartTime", Global.System.Data.DataRowVersion.Current, False, Nothing))
            Me._adapter.UpdateCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("EndTime", Global.System.Data.OleDb.OleDbType.Date, 0, Global.System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "EndTime", Global.System.Data.DataRowVersion.Current, False, Nothing))
            Me._adapter.UpdateCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("Original_ID", Global.System.Data.OleDb.OleDbType.Integer, 0, Global.System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "ID", Global.System.Data.DataRowVersion.Original, False, Nothing))
            Me._adapter.UpdateCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("IsNull_Subject", Global.System.Data.OleDb.OleDbType.Integer, 0, Global.System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "Subject", Global.System.Data.DataRowVersion.Original, True, Nothing))
            Me._adapter.UpdateCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("Original_Subject", Global.System.Data.OleDb.OleDbType.VarWChar, 0, Global.System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "Subject", Global.System.Data.DataRowVersion.Original, False, Nothing))
            Me._adapter.UpdateCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("IsNull_Label", Global.System.Data.OleDb.OleDbType.Integer, 0, Global.System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "Label", Global.System.Data.DataRowVersion.Original, True, Nothing))
            Me._adapter.UpdateCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("Original_Label", Global.System.Data.OleDb.OleDbType.Integer, 0, Global.System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "Label", Global.System.Data.DataRowVersion.Original, False, Nothing))
            Me._adapter.UpdateCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("IsNull_StartTime", Global.System.Data.OleDb.OleDbType.Integer, 0, Global.System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "StartTime", Global.System.Data.DataRowVersion.Original, True, Nothing))
            Me._adapter.UpdateCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("Original_StartTime", Global.System.Data.OleDb.OleDbType.Date, 0, Global.System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "StartTime", Global.System.Data.DataRowVersion.Original, False, Nothing))
            Me._adapter.UpdateCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("IsNull_EndTime", Global.System.Data.OleDb.OleDbType.Integer, 0, Global.System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "EndTime", Global.System.Data.DataRowVersion.Original, True, Nothing))
            Me._adapter.UpdateCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("Original_EndTime", Global.System.Data.OleDb.OleDbType.Date, 0, Global.System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "EndTime", Global.System.Data.DataRowVersion.Original, False, Nothing))
        End Sub

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Private Sub InitConnection()
            Me._connection = New Global.System.Data.OleDb.OleDbConnection()
            Me._connection.ConnectionString = My.Settings.Default.CarsDBConnectionString
        End Sub

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Private Sub InitCommandCollection()
            Me._commandCollection = New Global.System.Data.OleDb.OleDbCommand(0){}
            Me._commandCollection(0) = New Global.System.Data.OleDb.OleDbCommand()
            Me._commandCollection(0).Connection = Me.Connection
            Me._commandCollection(0).CommandText = "SELECT ID, Subject, Description, Label, StartTime, EndTime FROM CarScheduling"
            Me._commandCollection(0).CommandType = Global.System.Data.CommandType.Text
        End Sub

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter"), Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Fill, True)> _
        Public Overridable Function Fill(ByVal dataTable As CarsDBDataSet.CarSchedulingDataTable) As Integer
            Me.Adapter.SelectCommand = Me.CommandCollection(0)
            If (Me.ClearBeforeFill = True) Then
                dataTable.Clear()
            End If
            Dim returnValue As Integer = Me.Adapter.Fill(dataTable)
            Return returnValue
        End Function

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter"), Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Select, True)> _
        Public Overridable Function GetData() As CarsDBDataSet.CarSchedulingDataTable
            Me.Adapter.SelectCommand = Me.CommandCollection(0)
            Dim dataTable As New CarsDBDataSet.CarSchedulingDataTable()
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")> _
        Public Overridable Function Update(ByVal dataTable As CarsDBDataSet.CarSchedulingDataTable) As Integer
            Return Me.Adapter.Update(dataTable)
        End Function

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")> _
        Public Overridable Function Update(ByVal dataSet As CarsDBDataSet) As Integer
            Return Me.Adapter.Update(dataSet, "CarScheduling")
        End Function

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")> _
        Public Overridable Function Update(ByVal dataRow As Global.System.Data.DataRow) As Integer
            Return Me.Adapter.Update(New Global.System.Data.DataRow() { dataRow})
        End Function

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")> _
        Public Overridable Function Update(ByVal dataRows() As Global.System.Data.DataRow) As Integer
            Return Me.Adapter.Update(dataRows)
        End Function

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter"), Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Delete, True)> _
        Public Overridable Function Delete(ByVal Original_ID As Integer, ByVal Original_Subject As String, ByVal Original_Label? As Integer, ByVal Original_StartTime? As Global.System.DateTime, ByVal Original_EndTime? As Global.System.DateTime) As Integer
            Me.Adapter.DeleteCommand.Parameters(0).Value = (CInt(Original_ID))
            If (Original_Subject Is Nothing) Then
                Me.Adapter.DeleteCommand.Parameters(1).Value = (DirectCast(1, Object))
                Me.Adapter.DeleteCommand.Parameters(2).Value = Global.System.DBNull.Value
            Else
                Me.Adapter.DeleteCommand.Parameters(1).Value = (DirectCast(0, Object))
                Me.Adapter.DeleteCommand.Parameters(2).Value = (CStr(Original_Subject))
            End If
            If (Original_Label.HasValue = True) Then
                Me.Adapter.DeleteCommand.Parameters(3).Value = (DirectCast(0, Object))
                Me.Adapter.DeleteCommand.Parameters(4).Value = (CInt(Original_Label.Value))
            Else
                Me.Adapter.DeleteCommand.Parameters(3).Value = (DirectCast(1, Object))
                Me.Adapter.DeleteCommand.Parameters(4).Value = Global.System.DBNull.Value
            End If
            If (Original_StartTime.HasValue = True) Then
                Me.Adapter.DeleteCommand.Parameters(5).Value = (DirectCast(0, Object))
                Me.Adapter.DeleteCommand.Parameters(6).Value = (CDate(Original_StartTime.Value))
            Else
                Me.Adapter.DeleteCommand.Parameters(5).Value = (DirectCast(1, Object))
                Me.Adapter.DeleteCommand.Parameters(6).Value = Global.System.DBNull.Value
            End If
            If (Original_EndTime.HasValue = True) Then
                Me.Adapter.DeleteCommand.Parameters(7).Value = (DirectCast(0, Object))
                Me.Adapter.DeleteCommand.Parameters(8).Value = (CDate(Original_EndTime.Value))
            Else
                Me.Adapter.DeleteCommand.Parameters(7).Value = (DirectCast(1, Object))
                Me.Adapter.DeleteCommand.Parameters(8).Value = Global.System.DBNull.Value
            End If
            Dim previousConnectionState As Global.System.Data.ConnectionState = Me.Adapter.DeleteCommand.Connection.State
            If ((Me.Adapter.DeleteCommand.Connection.State And Global.System.Data.ConnectionState.Open) <> Global.System.Data.ConnectionState.Open) Then
                Me.Adapter.DeleteCommand.Connection.Open()
            End If
            Try
                Dim returnValue As Integer = Me.Adapter.DeleteCommand.ExecuteNonQuery()
                Return returnValue
            Finally
                If (previousConnectionState = Global.System.Data.ConnectionState.Closed) Then
                    Me.Adapter.DeleteCommand.Connection.Close()
                End If
            End Try
        End Function

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter"), Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Insert, True)> _
        Public Overridable Function Insert(ByVal Subject As String, ByVal Description As String, ByVal Label? As Integer, ByVal StartTime? As Global.System.DateTime, ByVal EndTime? As Global.System.DateTime) As Integer
            If (Subject Is Nothing) Then
                Me.Adapter.InsertCommand.Parameters(0).Value = Global.System.DBNull.Value
            Else
                Me.Adapter.InsertCommand.Parameters(0).Value = (CStr(Subject))
            End If
            If (Description Is Nothing) Then
                Me.Adapter.InsertCommand.Parameters(1).Value = Global.System.DBNull.Value
            Else
                Me.Adapter.InsertCommand.Parameters(1).Value = (CStr(Description))
            End If
            If (Label.HasValue = True) Then
                Me.Adapter.InsertCommand.Parameters(2).Value = (CInt(Label.Value))
            Else
                Me.Adapter.InsertCommand.Parameters(2).Value = Global.System.DBNull.Value
            End If
            If (StartTime.HasValue = True) Then
                Me.Adapter.InsertCommand.Parameters(3).Value = (CDate(StartTime.Value))
            Else
                Me.Adapter.InsertCommand.Parameters(3).Value = Global.System.DBNull.Value
            End If
            If (EndTime.HasValue = True) Then
                Me.Adapter.InsertCommand.Parameters(4).Value = (CDate(EndTime.Value))
            Else
                Me.Adapter.InsertCommand.Parameters(4).Value = Global.System.DBNull.Value
            End If
            Dim previousConnectionState As Global.System.Data.ConnectionState = Me.Adapter.InsertCommand.Connection.State
            If ((Me.Adapter.InsertCommand.Connection.State And Global.System.Data.ConnectionState.Open) <> Global.System.Data.ConnectionState.Open) Then
                Me.Adapter.InsertCommand.Connection.Open()
            End If
            Try
                Dim returnValue As Integer = Me.Adapter.InsertCommand.ExecuteNonQuery()
                Return returnValue
            Finally
                If (previousConnectionState = Global.System.Data.ConnectionState.Closed) Then
                    Me.Adapter.InsertCommand.Connection.Close()
                End If
            End Try
        End Function

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter"), Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Update, True)> _
        Public Overridable Function Update(ByVal Subject As String, ByVal Description As String, ByVal Label? As Integer, ByVal StartTime? As Global.System.DateTime, ByVal EndTime? As Global.System.DateTime, ByVal Original_ID As Integer, ByVal Original_Subject As String, ByVal Original_Label? As Integer, ByVal Original_StartTime? As Global.System.DateTime, ByVal Original_EndTime? As Global.System.DateTime) As Integer
            If (Subject Is Nothing) Then
                Me.Adapter.UpdateCommand.Parameters(0).Value = Global.System.DBNull.Value
            Else
                Me.Adapter.UpdateCommand.Parameters(0).Value = (CStr(Subject))
            End If
            If (Description Is Nothing) Then
                Me.Adapter.UpdateCommand.Parameters(1).Value = Global.System.DBNull.Value
            Else
                Me.Adapter.UpdateCommand.Parameters(1).Value = (CStr(Description))
            End If
            If (Label.HasValue = True) Then
                Me.Adapter.UpdateCommand.Parameters(2).Value = (CInt(Label.Value))
            Else
                Me.Adapter.UpdateCommand.Parameters(2).Value = Global.System.DBNull.Value
            End If
            If (StartTime.HasValue = True) Then
                Me.Adapter.UpdateCommand.Parameters(3).Value = (CDate(StartTime.Value))
            Else
                Me.Adapter.UpdateCommand.Parameters(3).Value = Global.System.DBNull.Value
            End If
            If (EndTime.HasValue = True) Then
                Me.Adapter.UpdateCommand.Parameters(4).Value = (CDate(EndTime.Value))
            Else
                Me.Adapter.UpdateCommand.Parameters(4).Value = Global.System.DBNull.Value
            End If
            Me.Adapter.UpdateCommand.Parameters(5).Value = (CInt(Original_ID))
            If (Original_Subject Is Nothing) Then
                Me.Adapter.UpdateCommand.Parameters(6).Value = (DirectCast(1, Object))
                Me.Adapter.UpdateCommand.Parameters(7).Value = Global.System.DBNull.Value
            Else
                Me.Adapter.UpdateCommand.Parameters(6).Value = (DirectCast(0, Object))
                Me.Adapter.UpdateCommand.Parameters(7).Value = (CStr(Original_Subject))
            End If
            If (Original_Label.HasValue = True) Then
                Me.Adapter.UpdateCommand.Parameters(8).Value = (DirectCast(0, Object))
                Me.Adapter.UpdateCommand.Parameters(9).Value = (CInt(Original_Label.Value))
            Else
                Me.Adapter.UpdateCommand.Parameters(8).Value = (DirectCast(1, Object))
                Me.Adapter.UpdateCommand.Parameters(9).Value = Global.System.DBNull.Value
            End If
            If (Original_StartTime.HasValue = True) Then
                Me.Adapter.UpdateCommand.Parameters(10).Value = (DirectCast(0, Object))
                Me.Adapter.UpdateCommand.Parameters(11).Value = (CDate(Original_StartTime.Value))
            Else
                Me.Adapter.UpdateCommand.Parameters(10).Value = (DirectCast(1, Object))
                Me.Adapter.UpdateCommand.Parameters(11).Value = Global.System.DBNull.Value
            End If
            If (Original_EndTime.HasValue = True) Then
                Me.Adapter.UpdateCommand.Parameters(12).Value = (DirectCast(0, Object))
                Me.Adapter.UpdateCommand.Parameters(13).Value = (CDate(Original_EndTime.Value))
            Else
                Me.Adapter.UpdateCommand.Parameters(12).Value = (DirectCast(1, Object))
                Me.Adapter.UpdateCommand.Parameters(13).Value = Global.System.DBNull.Value
            End If
            Dim previousConnectionState As Global.System.Data.ConnectionState = Me.Adapter.UpdateCommand.Connection.State
            If ((Me.Adapter.UpdateCommand.Connection.State And Global.System.Data.ConnectionState.Open) <> Global.System.Data.ConnectionState.Open) Then
                Me.Adapter.UpdateCommand.Connection.Open()
            End If
            Try
                Dim returnValue As Integer = Me.Adapter.UpdateCommand.ExecuteNonQuery()
                Return returnValue
            Finally
                If (previousConnectionState = Global.System.Data.ConnectionState.Closed) Then
                    Me.Adapter.UpdateCommand.Connection.Close()
                End If
            End Try
        End Function
    End Class

    ''' <summary>
    '''Represents the connection and commands used to retrieve and save data.
    '''</summary>
    <Global.System.ComponentModel.DesignerCategoryAttribute("code"), Global.System.ComponentModel.ToolboxItem(True), Global.System.ComponentModel.DataObjectAttribute(True), Global.System.ComponentModel.DesignerAttribute("Microsoft.VSDesigner.DataSource.Design.TableAdapterDesigner, Microsoft.VSDesigner" & ", Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")> _
    Partial Public Class LabelsTableAdapter
        Inherits System.ComponentModel.Component

        Private _adapter As Global.System.Data.OleDb.OleDbDataAdapter

        Private _connection As Global.System.Data.OleDb.OleDbConnection

        Private _transaction As Global.System.Data.OleDb.OleDbTransaction

        Private _commandCollection() As Global.System.Data.OleDb.OleDbCommand

        Private _clearBeforeFill As Boolean

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Public Sub New()
            Me.ClearBeforeFill = True
        End Sub

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Protected Friend ReadOnly Property Adapter() As Global.System.Data.OleDb.OleDbDataAdapter
            Get
                If (Me._adapter Is Nothing) Then
                    Me.InitAdapter()
                End If
                Return Me._adapter
            End Get
        End Property

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Friend Property Connection() As Global.System.Data.OleDb.OleDbConnection
            Get
                If (Me._connection Is Nothing) Then
                    Me.InitConnection()
                End If
                Return Me._connection
            End Get
            Set(ByVal value As System.Data.OleDb.OleDbConnection)
                Me._connection = value
                If (Me.Adapter.InsertCommand IsNot Nothing) Then
                    Me.Adapter.InsertCommand.Connection = value
                End If
                If (Me.Adapter.DeleteCommand IsNot Nothing) Then
                    Me.Adapter.DeleteCommand.Connection = value
                End If
                If (Me.Adapter.UpdateCommand IsNot Nothing) Then
                    Me.Adapter.UpdateCommand.Connection = value
                End If
                Dim i As Integer = 0
                Do While (i < Me.CommandCollection.Length)
                    If (Me.CommandCollection(i) IsNot Nothing) Then
                        CType(Me.CommandCollection(i), Global.System.Data.OleDb.OleDbCommand).Connection = value
                    End If
                    i = (i + 1)
                Loop
            End Set
        End Property

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Friend Property Transaction() As Global.System.Data.OleDb.OleDbTransaction
            Get
                Return Me._transaction
            End Get
            Set(ByVal value As System.Data.OleDb.OleDbTransaction)
                Me._transaction = value
                Dim i As Integer = 0
                Do While (i < Me.CommandCollection.Length)
                    Me.CommandCollection(i).Transaction = Me._transaction
                    i = (i + 1)
                Loop
                If ((Me.Adapter IsNot Nothing) AndAlso (Me.Adapter.DeleteCommand IsNot Nothing)) Then
                    Me.Adapter.DeleteCommand.Transaction = Me._transaction
                End If
                If ((Me.Adapter IsNot Nothing) AndAlso (Me.Adapter.InsertCommand IsNot Nothing)) Then
                    Me.Adapter.InsertCommand.Transaction = Me._transaction
                End If
                If ((Me.Adapter IsNot Nothing) AndAlso (Me.Adapter.UpdateCommand IsNot Nothing)) Then
                    Me.Adapter.UpdateCommand.Transaction = Me._transaction
                End If
            End Set
        End Property

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Protected ReadOnly Property CommandCollection() As Global.System.Data.OleDb.OleDbCommand()
            Get
                If (Me._commandCollection Is Nothing) Then
                    Me.InitCommandCollection()
                End If
                Return Me._commandCollection
            End Get
        End Property

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Public Property ClearBeforeFill() As Boolean
            Get
                Return Me._clearBeforeFill
            End Get
            Set(ByVal value As Boolean)
                Me._clearBeforeFill = value
            End Set
        End Property

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Private Sub InitAdapter()
            Me._adapter = New Global.System.Data.OleDb.OleDbDataAdapter()
            Dim tableMapping As New Global.System.Data.Common.DataTableMapping()
            tableMapping.SourceTable = "Table"
            tableMapping.DataSetTable = "Labels"
            tableMapping.ColumnMappings.Add("ID", "ID")
            tableMapping.ColumnMappings.Add("Color", "Color")
            tableMapping.ColumnMappings.Add("DisplayName", "DisplayName")
            Me._adapter.TableMappings.Add(tableMapping)
            Me._adapter.DeleteCommand = New Global.System.Data.OleDb.OleDbCommand()
            Me._adapter.DeleteCommand.Connection = Me.Connection
            Me._adapter.DeleteCommand.CommandText = "DELETE FROM `Labels` WHERE ((`ID` = ?) AND ((? = 1 AND `Color` IS NULL) OR (`Colo" & "r` = ?)) AND ((? = 1 AND `DisplayName` IS NULL) OR (`DisplayName` = ?)))"
            Me._adapter.DeleteCommand.CommandType = Global.System.Data.CommandType.Text
            Me._adapter.DeleteCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("Original_ID", Global.System.Data.OleDb.OleDbType.Integer, 0, Global.System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "ID", Global.System.Data.DataRowVersion.Original, False, Nothing))
            Me._adapter.DeleteCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("IsNull_Color", Global.System.Data.OleDb.OleDbType.Integer, 0, Global.System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "Color", Global.System.Data.DataRowVersion.Original, True, Nothing))
            Me._adapter.DeleteCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("Original_Color", Global.System.Data.OleDb.OleDbType.Integer, 0, Global.System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "Color", Global.System.Data.DataRowVersion.Original, False, Nothing))
            Me._adapter.DeleteCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("IsNull_DisplayName", Global.System.Data.OleDb.OleDbType.Integer, 0, Global.System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "DisplayName", Global.System.Data.DataRowVersion.Original, True, Nothing))
            Me._adapter.DeleteCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("Original_DisplayName", Global.System.Data.OleDb.OleDbType.VarWChar, 0, Global.System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "DisplayName", Global.System.Data.DataRowVersion.Original, False, Nothing))
            Me._adapter.InsertCommand = New Global.System.Data.OleDb.OleDbCommand()
            Me._adapter.InsertCommand.Connection = Me.Connection
            Me._adapter.InsertCommand.CommandText = "INSERT INTO `Labels` (`ID`, `Color`, `DisplayName`) VALUES (?, ?, ?)"
            Me._adapter.InsertCommand.CommandType = Global.System.Data.CommandType.Text
            Me._adapter.InsertCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("ID", Global.System.Data.OleDb.OleDbType.Integer, 0, Global.System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "ID", Global.System.Data.DataRowVersion.Current, False, Nothing))
            Me._adapter.InsertCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("Color", Global.System.Data.OleDb.OleDbType.Integer, 0, Global.System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "Color", Global.System.Data.DataRowVersion.Current, False, Nothing))
            Me._adapter.InsertCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("DisplayName", Global.System.Data.OleDb.OleDbType.VarWChar, 0, Global.System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "DisplayName", Global.System.Data.DataRowVersion.Current, False, Nothing))
            Me._adapter.UpdateCommand = New Global.System.Data.OleDb.OleDbCommand()
            Me._adapter.UpdateCommand.Connection = Me.Connection
            Me._adapter.UpdateCommand.CommandText = "UPDATE `Labels` SET `ID` = ?, `Color` = ?, `DisplayName` = ? WHERE ((`ID` = ?) AN" & "D ((? = 1 AND `Color` IS NULL) OR (`Color` = ?)) AND ((? = 1 AND `DisplayName` I" & "S NULL) OR (`DisplayName` = ?)))"
            Me._adapter.UpdateCommand.CommandType = Global.System.Data.CommandType.Text
            Me._adapter.UpdateCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("ID", Global.System.Data.OleDb.OleDbType.Integer, 0, Global.System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "ID", Global.System.Data.DataRowVersion.Current, False, Nothing))
            Me._adapter.UpdateCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("Color", Global.System.Data.OleDb.OleDbType.Integer, 0, Global.System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "Color", Global.System.Data.DataRowVersion.Current, False, Nothing))
            Me._adapter.UpdateCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("DisplayName", Global.System.Data.OleDb.OleDbType.VarWChar, 0, Global.System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "DisplayName", Global.System.Data.DataRowVersion.Current, False, Nothing))
            Me._adapter.UpdateCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("Original_ID", Global.System.Data.OleDb.OleDbType.Integer, 0, Global.System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "ID", Global.System.Data.DataRowVersion.Original, False, Nothing))
            Me._adapter.UpdateCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("IsNull_Color", Global.System.Data.OleDb.OleDbType.Integer, 0, Global.System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "Color", Global.System.Data.DataRowVersion.Original, True, Nothing))
            Me._adapter.UpdateCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("Original_Color", Global.System.Data.OleDb.OleDbType.Integer, 0, Global.System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "Color", Global.System.Data.DataRowVersion.Original, False, Nothing))
            Me._adapter.UpdateCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("IsNull_DisplayName", Global.System.Data.OleDb.OleDbType.Integer, 0, Global.System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "DisplayName", Global.System.Data.DataRowVersion.Original, True, Nothing))
            Me._adapter.UpdateCommand.Parameters.Add(New Global.System.Data.OleDb.OleDbParameter("Original_DisplayName", Global.System.Data.OleDb.OleDbType.VarWChar, 0, Global.System.Data.ParameterDirection.Input, (CByte(0)), (CByte(0)), "DisplayName", Global.System.Data.DataRowVersion.Original, False, Nothing))
        End Sub

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Private Sub InitConnection()
            Me._connection = New Global.System.Data.OleDb.OleDbConnection()
            Me._connection.ConnectionString = My.Settings.Default.CarsDBConnectionString
        End Sub

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Private Sub InitCommandCollection()
            Me._commandCollection = New Global.System.Data.OleDb.OleDbCommand(0){}
            Me._commandCollection(0) = New Global.System.Data.OleDb.OleDbCommand()
            Me._commandCollection(0).Connection = Me.Connection
            Me._commandCollection(0).CommandText = "SELECT ID, Color, DisplayName FROM Labels"
            Me._commandCollection(0).CommandType = Global.System.Data.CommandType.Text
        End Sub

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter"), Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Fill, True)> _
        Public Overridable Function Fill(ByVal dataTable As CarsDBDataSet.LabelsDataTable) As Integer
            Me.Adapter.SelectCommand = Me.CommandCollection(0)
            If (Me.ClearBeforeFill = True) Then
                dataTable.Clear()
            End If
            Dim returnValue As Integer = Me.Adapter.Fill(dataTable)
            Return returnValue
        End Function

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter"), Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Select, True)> _
        Public Overridable Function GetData() As CarsDBDataSet.LabelsDataTable
            Me.Adapter.SelectCommand = Me.CommandCollection(0)
            Dim dataTable As New CarsDBDataSet.LabelsDataTable()
            Me.Adapter.Fill(dataTable)
            Return dataTable
        End Function

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")> _
        Public Overridable Function Update(ByVal dataTable As CarsDBDataSet.LabelsDataTable) As Integer
            Return Me.Adapter.Update(dataTable)
        End Function

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")> _
        Public Overridable Function Update(ByVal dataSet As CarsDBDataSet) As Integer
            Return Me.Adapter.Update(dataSet, "Labels")
        End Function

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")> _
        Public Overridable Function Update(ByVal dataRow As Global.System.Data.DataRow) As Integer
            Return Me.Adapter.Update(New Global.System.Data.DataRow() { dataRow})
        End Function

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")> _
        Public Overridable Function Update(ByVal dataRows() As Global.System.Data.DataRow) As Integer
            Return Me.Adapter.Update(dataRows)
        End Function

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter"), Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Delete, True)> _
        Public Overridable Function Delete(ByVal Original_ID? As Integer, ByVal Original_Color? As Integer, ByVal Original_DisplayName As String) As Integer
            If (Original_ID.HasValue = True) Then
                Me.Adapter.DeleteCommand.Parameters(0).Value = (CInt(Original_ID.Value))
            Else
                Me.Adapter.DeleteCommand.Parameters(0).Value = Global.System.DBNull.Value
            End If
            If (Original_Color.HasValue = True) Then
                Me.Adapter.DeleteCommand.Parameters(1).Value = (DirectCast(0, Object))
                Me.Adapter.DeleteCommand.Parameters(2).Value = (CInt(Original_Color.Value))
            Else
                Me.Adapter.DeleteCommand.Parameters(1).Value = (DirectCast(1, Object))
                Me.Adapter.DeleteCommand.Parameters(2).Value = Global.System.DBNull.Value
            End If
            If (Original_DisplayName Is Nothing) Then
                Me.Adapter.DeleteCommand.Parameters(3).Value = (DirectCast(1, Object))
                Me.Adapter.DeleteCommand.Parameters(4).Value = Global.System.DBNull.Value
            Else
                Me.Adapter.DeleteCommand.Parameters(3).Value = (DirectCast(0, Object))
                Me.Adapter.DeleteCommand.Parameters(4).Value = (CStr(Original_DisplayName))
            End If
            Dim previousConnectionState As Global.System.Data.ConnectionState = Me.Adapter.DeleteCommand.Connection.State
            If ((Me.Adapter.DeleteCommand.Connection.State And Global.System.Data.ConnectionState.Open) <> Global.System.Data.ConnectionState.Open) Then
                Me.Adapter.DeleteCommand.Connection.Open()
            End If
            Try
                Dim returnValue As Integer = Me.Adapter.DeleteCommand.ExecuteNonQuery()
                Return returnValue
            Finally
                If (previousConnectionState = Global.System.Data.ConnectionState.Closed) Then
                    Me.Adapter.DeleteCommand.Connection.Close()
                End If
            End Try
        End Function

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter"), Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Insert, True)> _
        Public Overridable Function Insert(ByVal ID? As Integer, ByVal Color? As Integer, ByVal DisplayName As String) As Integer
            If (ID.HasValue = True) Then
                Me.Adapter.InsertCommand.Parameters(0).Value = (CInt(ID.Value))
            Else
                Me.Adapter.InsertCommand.Parameters(0).Value = Global.System.DBNull.Value
            End If
            If (Color.HasValue = True) Then
                Me.Adapter.InsertCommand.Parameters(1).Value = (CInt(Color.Value))
            Else
                Me.Adapter.InsertCommand.Parameters(1).Value = Global.System.DBNull.Value
            End If
            If (DisplayName Is Nothing) Then
                Me.Adapter.InsertCommand.Parameters(2).Value = Global.System.DBNull.Value
            Else
                Me.Adapter.InsertCommand.Parameters(2).Value = (CStr(DisplayName))
            End If
            Dim previousConnectionState As Global.System.Data.ConnectionState = Me.Adapter.InsertCommand.Connection.State
            If ((Me.Adapter.InsertCommand.Connection.State And Global.System.Data.ConnectionState.Open) <> Global.System.Data.ConnectionState.Open) Then
                Me.Adapter.InsertCommand.Connection.Open()
            End If
            Try
                Dim returnValue As Integer = Me.Adapter.InsertCommand.ExecuteNonQuery()
                Return returnValue
            Finally
                If (previousConnectionState = Global.System.Data.ConnectionState.Closed) Then
                    Me.Adapter.InsertCommand.Connection.Close()
                End If
            End Try
        End Function

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter"), Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Update, True)> _
        Public Overridable Function Update(ByVal ID? As Integer, ByVal Color? As Integer, ByVal DisplayName As String, ByVal Original_ID? As Integer, ByVal Original_Color? As Integer, ByVal Original_DisplayName As String) As Integer
            If (ID.HasValue = True) Then
                Me.Adapter.UpdateCommand.Parameters(0).Value = (CInt(ID.Value))
            Else
                Me.Adapter.UpdateCommand.Parameters(0).Value = Global.System.DBNull.Value
            End If
            If (Color.HasValue = True) Then
                Me.Adapter.UpdateCommand.Parameters(1).Value = (CInt(Color.Value))
            Else
                Me.Adapter.UpdateCommand.Parameters(1).Value = Global.System.DBNull.Value
            End If
            If (DisplayName Is Nothing) Then
                Me.Adapter.UpdateCommand.Parameters(2).Value = Global.System.DBNull.Value
            Else
                Me.Adapter.UpdateCommand.Parameters(2).Value = (CStr(DisplayName))
            End If
            If (Original_ID.HasValue = True) Then
                Me.Adapter.UpdateCommand.Parameters(3).Value = (CInt(Original_ID.Value))
            Else
                Me.Adapter.UpdateCommand.Parameters(3).Value = Global.System.DBNull.Value
            End If
            If (Original_Color.HasValue = True) Then
                Me.Adapter.UpdateCommand.Parameters(4).Value = (DirectCast(0, Object))
                Me.Adapter.UpdateCommand.Parameters(5).Value = (CInt(Original_Color.Value))
            Else
                Me.Adapter.UpdateCommand.Parameters(4).Value = (DirectCast(1, Object))
                Me.Adapter.UpdateCommand.Parameters(5).Value = Global.System.DBNull.Value
            End If
            If (Original_DisplayName Is Nothing) Then
                Me.Adapter.UpdateCommand.Parameters(6).Value = (DirectCast(1, Object))
                Me.Adapter.UpdateCommand.Parameters(7).Value = Global.System.DBNull.Value
            Else
                Me.Adapter.UpdateCommand.Parameters(6).Value = (DirectCast(0, Object))
                Me.Adapter.UpdateCommand.Parameters(7).Value = (CStr(Original_DisplayName))
            End If
            Dim previousConnectionState As Global.System.Data.ConnectionState = Me.Adapter.UpdateCommand.Connection.State
            If ((Me.Adapter.UpdateCommand.Connection.State And Global.System.Data.ConnectionState.Open) <> Global.System.Data.ConnectionState.Open) Then
                Me.Adapter.UpdateCommand.Connection.Open()
            End If
            Try
                Dim returnValue As Integer = Me.Adapter.UpdateCommand.ExecuteNonQuery()
                Return returnValue
            Finally
                If (previousConnectionState = Global.System.Data.ConnectionState.Closed) Then
                    Me.Adapter.UpdateCommand.Connection.Close()
                End If
            End Try
        End Function

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter"), Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Update, True)> _
        Public Overridable Function Update(ByVal Color? As Integer, ByVal DisplayName As String, ByVal Original_ID? As Integer, ByVal Original_Color? As Integer, ByVal Original_DisplayName As String) As Integer
            Return Me.Update(Original_ID, Color, DisplayName, Original_ID, Original_Color, Original_DisplayName)
        End Function
    End Class

    ''' <summary>
    '''TableAdapterManager is used to coordinate TableAdapters in the dataset to enable Hierarchical Update scenarios
    '''</summary>
    <Global.System.ComponentModel.DesignerCategoryAttribute("code"), Global.System.ComponentModel.ToolboxItem(True), Global.System.ComponentModel.DesignerAttribute("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerDesigner, Microsoft.VSD" & "esigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"), Global.System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapterManager")> _
    Partial Public Class TableAdapterManager
        Inherits System.ComponentModel.Component

        Private _updateOrder As UpdateOrderOption

        Private _carSchedulingTableAdapter As CarSchedulingTableAdapter

        Private _labelsTableAdapter As LabelsTableAdapter

        Private _backupDataSetBeforeUpdate As Boolean

        Private _connection As Global.System.Data.IDbConnection

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Public Property UpdateOrder() As UpdateOrderOption
            Get
                Return Me._updateOrder
            End Get
            Set(ByVal value As UpdateOrderOption)
                Me._updateOrder = value
            End Set
        End Property

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Global.System.ComponentModel.EditorAttribute("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microso" & "ft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3" & "a", "System.Drawing.Design.UITypeEditor")> _
        Public Property CarSchedulingTableAdapter() As CarSchedulingTableAdapter
            Get
                Return Me._carSchedulingTableAdapter
            End Get
            Set(ByVal value As CarSchedulingTableAdapter)
                Me._carSchedulingTableAdapter = value
            End Set
        End Property

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Global.System.ComponentModel.EditorAttribute("Microsoft.VSDesigner.DataSource.Design.TableAdapterManagerPropertyEditor, Microso" & "ft.VSDesigner, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3" & "a", "System.Drawing.Design.UITypeEditor")> _
        Public Property LabelsTableAdapter() As LabelsTableAdapter
            Get
                Return Me._labelsTableAdapter
            End Get
            Set(ByVal value As LabelsTableAdapter)
                Me._labelsTableAdapter = value
            End Set
        End Property

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Public Property BackupDataSetBeforeUpdate() As Boolean
            Get
                Return Me._backupDataSetBeforeUpdate
            End Get
            Set(ByVal value As Boolean)
                Me._backupDataSetBeforeUpdate = value
            End Set
        End Property

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Global.System.ComponentModel.Browsable(False)> _
        Public Property Connection() As Global.System.Data.IDbConnection
            Get
                If (Me._connection IsNot Nothing) Then
                    Return Me._connection
                End If
                If ((Me._carSchedulingTableAdapter IsNot Nothing) AndAlso (Me._carSchedulingTableAdapter.Connection IsNot Nothing)) Then
                    Return Me._carSchedulingTableAdapter.Connection
                End If
                If ((Me._labelsTableAdapter IsNot Nothing) AndAlso (Me._labelsTableAdapter.Connection IsNot Nothing)) Then
                    Return Me._labelsTableAdapter.Connection
                End If
                Return Nothing
            End Get
            Set(ByVal value As System.Data.IDbConnection)
                Me._connection = value
            End Set
        End Property

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0"), Global.System.ComponentModel.Browsable(False)> _
        Public ReadOnly Property TableAdapterInstanceCount() As Integer
            Get
                Dim count As Integer = 0
                If (Me._carSchedulingTableAdapter IsNot Nothing) Then
                    count = (count + 1)
                End If
                If (Me._labelsTableAdapter IsNot Nothing) Then
                    count = (count + 1)
                End If
                Return count
            End Get
        End Property

        ''' <summary>
        '''Update rows in top-down order.
        '''</summary>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Private Function UpdateUpdatedRows(ByVal dataSet As CarsDBDataSet, ByVal allChangedRows As Global.System.Collections.Generic.List(Of Global.System.Data.DataRow), ByVal allAddedRows As Global.System.Collections.Generic.List(Of Global.System.Data.DataRow)) As Integer
            Dim result As Integer = 0
            If (Me._labelsTableAdapter IsNot Nothing) Then
                Dim updatedRows() As Global.System.Data.DataRow = dataSet.Labels.Select(Nothing, Nothing, Global.System.Data.DataViewRowState.ModifiedCurrent)
                updatedRows = Me.GetRealUpdatedRows(updatedRows, allAddedRows)
                If ((updatedRows IsNot Nothing) AndAlso (0 < updatedRows.Length)) Then
                    result = (result + Me._labelsTableAdapter.Update(updatedRows))
                    allChangedRows.AddRange(updatedRows)
                End If
            End If
            If (Me._carSchedulingTableAdapter IsNot Nothing) Then
                Dim updatedRows() As Global.System.Data.DataRow = dataSet.CarScheduling.Select(Nothing, Nothing, Global.System.Data.DataViewRowState.ModifiedCurrent)
                updatedRows = Me.GetRealUpdatedRows(updatedRows, allAddedRows)
                If ((updatedRows IsNot Nothing) AndAlso (0 < updatedRows.Length)) Then
                    result = (result + Me._carSchedulingTableAdapter.Update(updatedRows))
                    allChangedRows.AddRange(updatedRows)
                End If
            End If
            Return result
        End Function

        ''' <summary>
        '''Insert rows in top-down order.
        '''</summary>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Private Function UpdateInsertedRows(ByVal dataSet As CarsDBDataSet, ByVal allAddedRows As Global.System.Collections.Generic.List(Of Global.System.Data.DataRow)) As Integer
            Dim result As Integer = 0
            If (Me._labelsTableAdapter IsNot Nothing) Then
                Dim addedRows() As Global.System.Data.DataRow = dataSet.Labels.Select(Nothing, Nothing, Global.System.Data.DataViewRowState.Added)
                If ((addedRows IsNot Nothing) AndAlso (0 < addedRows.Length)) Then
                    result = (result + Me._labelsTableAdapter.Update(addedRows))
                    allAddedRows.AddRange(addedRows)
                End If
            End If
            If (Me._carSchedulingTableAdapter IsNot Nothing) Then
                Dim addedRows() As Global.System.Data.DataRow = dataSet.CarScheduling.Select(Nothing, Nothing, Global.System.Data.DataViewRowState.Added)
                If ((addedRows IsNot Nothing) AndAlso (0 < addedRows.Length)) Then
                    result = (result + Me._carSchedulingTableAdapter.Update(addedRows))
                    allAddedRows.AddRange(addedRows)
                End If
            End If
            Return result
        End Function

        ''' <summary>
        '''Delete rows in bottom-up order.
        '''</summary>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Private Function UpdateDeletedRows(ByVal dataSet As CarsDBDataSet, ByVal allChangedRows As Global.System.Collections.Generic.List(Of Global.System.Data.DataRow)) As Integer
            Dim result As Integer = 0
            If (Me._carSchedulingTableAdapter IsNot Nothing) Then
                Dim deletedRows() As Global.System.Data.DataRow = dataSet.CarScheduling.Select(Nothing, Nothing, Global.System.Data.DataViewRowState.Deleted)
                If ((deletedRows IsNot Nothing) AndAlso (0 < deletedRows.Length)) Then
                    result = (result + Me._carSchedulingTableAdapter.Update(deletedRows))
                    allChangedRows.AddRange(deletedRows)
                End If
            End If
            If (Me._labelsTableAdapter IsNot Nothing) Then
                Dim deletedRows() As Global.System.Data.DataRow = dataSet.Labels.Select(Nothing, Nothing, Global.System.Data.DataViewRowState.Deleted)
                If ((deletedRows IsNot Nothing) AndAlso (0 < deletedRows.Length)) Then
                    result = (result + Me._labelsTableAdapter.Update(deletedRows))
                    allChangedRows.AddRange(deletedRows)
                End If
            End If
            Return result
        End Function

        ''' <summary>
        '''Remove inserted rows that become updated rows after calling TableAdapter.Update(inserted rows) first
        '''</summary>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Private Function GetRealUpdatedRows(ByVal updatedRows() As Global.System.Data.DataRow, ByVal allAddedRows As Global.System.Collections.Generic.List(Of Global.System.Data.DataRow)) As Global.System.Data.DataRow()
            If ((updatedRows Is Nothing) OrElse (updatedRows.Length < 1)) Then
                Return updatedRows
            End If
            If ((allAddedRows Is Nothing) OrElse (allAddedRows.Count < 1)) Then
                Return updatedRows
            End If
            Dim realUpdatedRows As New Global.System.Collections.Generic.List(Of Global.System.Data.DataRow)()
            Dim i As Integer = 0
            Do While (i < updatedRows.Length)
                Dim row As Global.System.Data.DataRow = updatedRows(i)
                If (allAddedRows.Contains(row) = False) Then
                    realUpdatedRows.Add(row)
                End If
                i = (i + 1)
            Loop
            Return realUpdatedRows.ToArray()
        End Function

        ''' <summary>
        '''Update all changes to the dataset.
        '''</summary>
        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Public Overridable Function UpdateAll(ByVal dataSet As CarsDBDataSet) As Integer
            If (dataSet Is Nothing) Then
                Throw New Global.System.ArgumentNullException("dataSet")
            End If
            If (dataSet.HasChanges() = False) Then
                Return 0
            End If
            If ((Me._carSchedulingTableAdapter IsNot Nothing) AndAlso (Me.MatchTableAdapterConnection(Me._carSchedulingTableAdapter.Connection) = False)) Then
                Throw New Global.System.ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection s" & "tring.")
            End If
            If ((Me._labelsTableAdapter IsNot Nothing) AndAlso (Me.MatchTableAdapterConnection(Me._labelsTableAdapter.Connection) = False)) Then
                Throw New Global.System.ArgumentException("All TableAdapters managed by a TableAdapterManager must use the same connection s" & "tring.")
            End If
            Dim workConnection As Global.System.Data.IDbConnection = Me.Connection
            If (workConnection Is Nothing) Then
                Throw New Global.System.ApplicationException("TableAdapterManager contains no connection information. Set each TableAdapterMana" & "ger TableAdapter property to a valid TableAdapter instance.")
            End If
            Dim workConnOpened As Boolean = False
            If ((workConnection.State And Global.System.Data.ConnectionState.Broken) = Global.System.Data.ConnectionState.Broken) Then
                workConnection.Close()
            End If
            If (workConnection.State = Global.System.Data.ConnectionState.Closed) Then
                workConnection.Open()
                workConnOpened = True
            End If
            Dim workTransaction As Global.System.Data.IDbTransaction = workConnection.BeginTransaction()
            If (workTransaction Is Nothing) Then
                Throw New Global.System.ApplicationException("The transaction cannot begin. The current data connection does not support transa" & "ctions or the current state is not allowing the transaction to begin.")
            End If
            Dim allChangedRows As New Global.System.Collections.Generic.List(Of Global.System.Data.DataRow)()
            Dim allAddedRows As New Global.System.Collections.Generic.List(Of Global.System.Data.DataRow)()
            Dim adaptersWithAcceptChangesDuringUpdate As New Global.System.Collections.Generic.List(Of Global.System.Data.Common.DataAdapter)()
            Dim revertConnections As New Global.System.Collections.Generic.Dictionary(Of Object, Global.System.Data.IDbConnection)()
            Dim result As Integer = 0
            Dim backupDataSet As Global.System.Data.DataSet = Nothing
            If Me.BackupDataSetBeforeUpdate Then
                backupDataSet = New Global.System.Data.DataSet()
                backupDataSet.Merge(dataSet)
            End If
            Try
                ' ---- Prepare for update -----------
                '
                If (Me._carSchedulingTableAdapter IsNot Nothing) Then
                    revertConnections.Add(Me._carSchedulingTableAdapter, Me._carSchedulingTableAdapter.Connection)
                    Me._carSchedulingTableAdapter.Connection = (DirectCast(workConnection, Global.System.Data.OleDb.OleDbConnection))
                    Me._carSchedulingTableAdapter.Transaction = (DirectCast(workTransaction, Global.System.Data.OleDb.OleDbTransaction))
                    If Me._carSchedulingTableAdapter.Adapter.AcceptChangesDuringUpdate Then
                        Me._carSchedulingTableAdapter.Adapter.AcceptChangesDuringUpdate = False
                        adaptersWithAcceptChangesDuringUpdate.Add(Me._carSchedulingTableAdapter.Adapter)
                    End If
                End If
                If (Me._labelsTableAdapter IsNot Nothing) Then
                    revertConnections.Add(Me._labelsTableAdapter, Me._labelsTableAdapter.Connection)
                    Me._labelsTableAdapter.Connection = (DirectCast(workConnection, Global.System.Data.OleDb.OleDbConnection))
                    Me._labelsTableAdapter.Transaction = (DirectCast(workTransaction, Global.System.Data.OleDb.OleDbTransaction))
                    If Me._labelsTableAdapter.Adapter.AcceptChangesDuringUpdate Then
                        Me._labelsTableAdapter.Adapter.AcceptChangesDuringUpdate = False
                        adaptersWithAcceptChangesDuringUpdate.Add(Me._labelsTableAdapter.Adapter)
                    End If
                End If
                ' 
                '---- Perform updates -----------
                '
                If (Me.UpdateOrder = UpdateOrderOption.UpdateInsertDelete) Then
                    result = (result + Me.UpdateUpdatedRows(dataSet, allChangedRows, allAddedRows))
                    result = (result + Me.UpdateInsertedRows(dataSet, allAddedRows))
                Else
                    result = (result + Me.UpdateInsertedRows(dataSet, allAddedRows))
                    result = (result + Me.UpdateUpdatedRows(dataSet, allChangedRows, allAddedRows))
                End If
                result = (result + Me.UpdateDeletedRows(dataSet, allChangedRows))
                ' 
                '---- Commit updates -----------
                '
                workTransaction.Commit()
                If (0 < allAddedRows.Count) Then
                    Dim rows(allAddedRows.Count - 1) As Global.System.Data.DataRow
                    allAddedRows.CopyTo(rows)
                    Dim i As Integer = 0
                    Do While (i < rows.Length)
                        Dim row As Global.System.Data.DataRow = rows(i)
                        row.AcceptChanges()
                        i = (i + 1)
                    Loop
                End If
                If (0 < allChangedRows.Count) Then
                    Dim rows(allChangedRows.Count - 1) As Global.System.Data.DataRow
                    allChangedRows.CopyTo(rows)
                    Dim i As Integer = 0
                    Do While (i < rows.Length)
                        Dim row As Global.System.Data.DataRow = rows(i)
                        row.AcceptChanges()
                        i = (i + 1)
                    Loop
                End If
            Catch ex As Global.System.Exception
                workTransaction.Rollback()
                ' ---- Restore the dataset -----------
                If Me.BackupDataSetBeforeUpdate Then
                    Global.System.Diagnostics.Debug.Assert((backupDataSet IsNot Nothing))
                    dataSet.Clear()
                    dataSet.Merge(backupDataSet)
                Else
                    If (0 < allAddedRows.Count) Then
                        Dim rows(allAddedRows.Count - 1) As Global.System.Data.DataRow
                        allAddedRows.CopyTo(rows)
                        Dim i As Integer = 0
                        Do While (i < rows.Length)
                            Dim row As Global.System.Data.DataRow = rows(i)
                            row.AcceptChanges()
                            row.SetAdded()
                            i = (i + 1)
                        Loop
                    End If
                End If
                Throw ex
            Finally
                If workConnOpened Then
                    workConnection.Close()
                End If
                If (Me._carSchedulingTableAdapter IsNot Nothing) Then
                    Me._carSchedulingTableAdapter.Connection = (DirectCast(revertConnections(Me._carSchedulingTableAdapter), Global.System.Data.OleDb.OleDbConnection))
                    Me._carSchedulingTableAdapter.Transaction = Nothing
                End If
                If (Me._labelsTableAdapter IsNot Nothing) Then
                    Me._labelsTableAdapter.Connection = (DirectCast(revertConnections(Me._labelsTableAdapter), Global.System.Data.OleDb.OleDbConnection))
                    Me._labelsTableAdapter.Transaction = Nothing
                End If
                If (0 < adaptersWithAcceptChangesDuringUpdate.Count) Then
                    Dim adapters(adaptersWithAcceptChangesDuringUpdate.Count - 1) As Global.System.Data.Common.DataAdapter
                    adaptersWithAcceptChangesDuringUpdate.CopyTo(adapters)
                    Dim i As Integer = 0
                    Do While (i < adapters.Length)
                        Dim adapter As Global.System.Data.Common.DataAdapter = adapters(i)
                        adapter.AcceptChangesDuringUpdate = True
                        i = (i + 1)
                    Loop
                End If
            End Try
            Return result
        End Function

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Protected Overridable Sub SortSelfReferenceRows(ByVal rows() As Global.System.Data.DataRow, ByVal relation As Global.System.Data.DataRelation, ByVal childFirst As Boolean)
            Global.System.Array.Sort(Of Global.System.Data.DataRow)(rows, New SelfReferenceComparer(relation, childFirst))
        End Sub

        <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Protected Overridable Function MatchTableAdapterConnection(ByVal inputConnection As Global.System.Data.IDbConnection) As Boolean
            If (Me._connection IsNot Nothing) Then
                Return True
            End If
            If ((Me.Connection Is Nothing) OrElse (inputConnection Is Nothing)) Then
                Return True
            End If
            If String.Equals(Me.Connection.ConnectionString, inputConnection.ConnectionString, Global.System.StringComparison.Ordinal) Then
                Return True
            End If
            Return False
        End Function

        ''' <summary>
        '''Update Order Option
        '''</summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Public Enum UpdateOrderOption

            InsertUpdateDelete = 0

            UpdateInsertDelete = 1
        End Enum

        ''' <summary>
        '''Used to sort self-referenced table's rows
        '''</summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
        Private Class SelfReferenceComparer
            Inherits Object
            Implements System.Collections.Generic.IComparer(Of System.Data.DataRow)

            Private _relation As Global.System.Data.DataRelation

            Private _childFirst As Integer

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Friend Sub New(ByVal relation As Global.System.Data.DataRelation, ByVal childFirst As Boolean)
                Me._relation = relation
                If childFirst Then
                    Me._childFirst = -1
                Else
                    Me._childFirst = 1
                End If
            End Sub

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Private Function GetRoot(ByVal row As Global.System.Data.DataRow, ByRef distance As Integer) As Global.System.Data.DataRow
                Global.System.Diagnostics.Debug.Assert((row IsNot Nothing))
                Dim root As Global.System.Data.DataRow = row
                distance = 0

                Dim traversedRows As Global.System.Collections.Generic.IDictionary(Of Global.System.Data.DataRow, Global.System.Data.DataRow) = New Global.System.Collections.Generic.Dictionary(Of Global.System.Data.DataRow, Global.System.Data.DataRow)()
                traversedRows(row) = row

                Dim parent As Global.System.Data.DataRow = row.GetParentRow(Me._relation, Global.System.Data.DataRowVersion.Default)
                Do While ((parent IsNot Nothing) AndAlso (traversedRows.ContainsKey(parent) = False))
                    distance = (distance + 1)
                    root = parent
                    traversedRows(parent) = parent
                    parent = parent.GetParentRow(Me._relation, Global.System.Data.DataRowVersion.Default)
                Loop

                If (distance = 0) Then
                    traversedRows.Clear()
                    traversedRows(row) = row
                    parent = row.GetParentRow(Me._relation, Global.System.Data.DataRowVersion.Original)
                    Do While ((parent IsNot Nothing) AndAlso (traversedRows.ContainsKey(parent) = False))
                        distance = (distance + 1)
                        root = parent
                        traversedRows(parent) = parent
                        parent = parent.GetParentRow(Me._relation, Global.System.Data.DataRowVersion.Original)
                    Loop
                End If

                Return root
            End Function

            <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")> _
            Public Function Compare(ByVal row1 As Global.System.Data.DataRow, ByVal row2 As Global.System.Data.DataRow) As Integer Implements IComparer(Of Global.System.Data.DataRow).Compare
                If Object.ReferenceEquals(row1, row2) Then
                    Return 0
                End If
                If (row1 Is Nothing) Then
                    Return -1
                End If
                If (row2 Is Nothing) Then
                    Return 1
                End If

                Dim distance1 As Integer = 0
                Dim root1 As Global.System.Data.DataRow = Me.GetRoot(row1, distance1)

                Dim distance2 As Integer = 0
                Dim root2 As Global.System.Data.DataRow = Me.GetRoot(row2, distance2)

                If Object.ReferenceEquals(root1, root2) Then
                    Return (Me._childFirst * distance1.CompareTo(distance2))
                Else
                    Global.System.Diagnostics.Debug.Assert(((root1.Table IsNot Nothing) AndAlso (root2.Table IsNot Nothing)))
                    If (root1.Table.Rows.IndexOf(root1) < root2.Table.Rows.IndexOf(root2)) Then
                        Return -1
                    Else
                        Return 1
                    End If
                End If
            End Function
        End Class
    End Class
End Namespace

'#pragma warning restore 1591