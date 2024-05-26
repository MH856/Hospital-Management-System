<%@ Page Title="About" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Prescriptions.aspx.cs" Inherits="ICT365_Assignment2.Prescriptions" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container">
        <div class="row">
            <div class="col-md-4 "></div>
            <div class="col">
                <h1 class="text-danger">Manage Priscriptions</h1>
            </div>
        </div>
        <div class="row">

            <div class="col-md-4">
                <div>
                    <h2 class="text-danger">Priscriptions Details</h2>
                </div>
                <div>

                </div>

                <div>
                    <form>
                        <div class="mb-3">
                            <label for="exampleInputEmail1" class="form-label">Patient</label>
                            <asp:DropDownList ID="PatientDDL" class="form-control" runat="server" OnSelectedIndexChanged="PatientDDL_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <br />
                        <div class="mb-3">
                            <label for="exampleInputEmail1" class="form-label">Treatment</label>
                            <asp:DropDownList ID="TreatmentDDL" class="form-control" runat="server" OnSelectedIndexChanged="TreatmentDDL_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                        </div>
                        <br />
                        <div class="mb-3">
                            <label for="exampleInputEmail1" class="form-label">Treatment Cost</label>
                            <input type="text" class="form-control" id="TreatCost" runat="server">
                        </div>
                        <br />
                        <div class="mb-3">
                            <label for="exampleInputEmail1" class="form-label">Medicines</label>
                            <input type="text" class="form-control" id="Medicines" runat="server">
                        </div>
                        <br />
                        <div class="mb-3">
                            <label for="exampleInputEmail1" class="form-label">Quantity</label>
                            <input type="text" class="form-control" id="MedQty" runat="server">
                        </div>
                        <br />
                        <asp:Button ID="PrescEditBtn" runat="server" Text="Edit" class="btn btn-danger" OnClick="PrescEditBtn_Click" />
                        <asp:Button ID="PrescAddBtn" runat="server" Text="Save" class="btn btn-danger" OnClick="AddBtn_Click" />                        
                        <asp:Button ID="PrescDeleteBtn" runat="server" Text="Delete" class="btn btn-danger" OnClick="PrescDeleteBtn_Click" />
                    </form>
                </div>
                <div>

                </div>
            </div>
            <div class="col-md-8">
                <div>
                    <h2 class="text-primary">Prescriptions List</h2>
                </div>
                <asp:GridView ID="PrescriptionGV" runat="server" CssClass="table table-condensed table-bordered table-hover" AutoGenerateSelectButton="true" BorderStyle="None" OnSelectedIndexChanged="PrescriptionGV_SelectedIndexChanged">
                    <AlternatingRowStyle CssClass="danger" />
                </asp:GridView>
            </div>
        </div>
        </div>
</asp:Content>
