<%@ Page Title="About" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Patient.aspx.cs" Inherits="ICT365_Assignment2.Patient" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container">
        <div class="row">
            <div class="col-md-4 "></div>
            <div class="col">
                <h1 class="text-danger">Manage Patient</h1>
            </div>
        </div>
        <div class="row">

            <div class="col-md-4">
                <div>
                    <h2 class="text-danger">Patient Details</h2>
                </div>
                <div>

                </div>

                <div>
                    <form>
                        <div class="mb-3">
                            <label for="exampleInputEmail1" class="form-label">Patient Name</label>
                            <input type="text" class="form-control" id="PatientName" runat="server">
                        </div>
                        <br />
                        <div class="mb-3">
                            <label for="exampleInputEmail1" class="form-label">Patient Phone</label>
                            <input type="text" class="form-control" id="PatientPhone" runat="server">
                        </div>
                        <br />
                        <div class="mb-3">
                            <label for="exampleInputEmail1" class="form-label">Patient Address</label>
                            <input type="text" class="form-control" id="PatientAddress" runat="server">
                        </div>
                        <br />
                        <div class="mb-3">
                            <label for="exampleInputEmail1" class="form-label">Patient D.O.B</label>
                            <input type="date" class="form-control" id="PatientDOB" runat="server">
                        </div>
                        <br />
                        <div class="mb-3">
                            <label for="exampleInputEmail1" class="form-label">Patient Gender</label>
                            <input type="text" class="form-control" id="PatientGender" runat="server">
                        </div>
                        <br />
                        <div class="mb-3">
                            <label for="exampleInputEmail1" class="form-label">Patient Allergies</label>
                            <input type="text" class="form-control" id="PatientAllergies" runat="server">
                        </div>
                        <br />
                        <asp:Button ID="EditBtnn" runat="server" Text="Edit" class="btn btn-danger" OnClick="EditBtnn_Click" />
                        <asp:Button ID="AddBtn" runat="server" Text="Save" class="btn btn-danger" OnClick="AddBtn_Click" />                        
                        <asp:Button ID="DeleteBtnn" runat="server" Text="Delete" class="btn btn-danger" OnClick="DeleteBtnn_Click" />
                    </form>
                </div>
                <div>

                </div>
            </div>
            <div class="col-md-8">
                <div>
                    <h2 class="text-primary">Patient List</h2>
                </div>
                <asp:GridView ID="PatientGV" runat="server" CssClass="table table-condensed table-bordered table-hover" AutoGenerateSelectButton="true" OnSelectedIndexChanged="PatientGV_SelectedIndexChanged" BorderStyle="None">
                    <AlternatingRowStyle CssClass="danger" />
                </asp:GridView>
            </div>
        </div>
        </div>
</asp:Content>
