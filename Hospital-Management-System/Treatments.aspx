<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Treatments.aspx.cs" Inherits="ICT365_Assignment2.Treatments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container">
        <div class="row">
            <div class="col-md-4 "></div>
            <div class="col">
                <h1 class="text-danger">Manage Treatments</h1>
            </div>
        </div>
        <div class="row">

            <div class="col-md-4">
                <div>
                    <h2 class="text-danger">Treatments Details</h2>
                </div>
                <div>

                </div>

                <div>
                    <form>
                        <div class="mb-3">
                            <label for="exampleInputEmail1" class="form-label">Treatment Name</label>
                            <input type="text" class="form-control" id="TreatName" runat="server">
                        </div>
                        <br />
                        <div class="mb-3">
                            <label for="exampleInputEmail1" class="form-label">Treatment Cost</label>
                            <input type="text" class="form-control" id="TreatCost" runat="server">
                        </div>
                        <br />
                        <div class="mb-3">
                            <label for="exampleInputEmail1" class="form-label">Treatment Description</label>
                            <input type="text" class="form-control" id="TreatDesc" runat="server">
                        </div>
                       <br /><br />

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
                    <h2 class="text-primary">Treatments List</h2>
                </div>
                <asp:GridView ID="TreatmentGV" runat="server" CssClass="table table-condensed table-bordered table-hover" AutoGenerateSelectButton="true" OnSelectedIndexChanged="TreatmentGV_SelectedIndexChanged" BorderStyle="None">
                    <AlternatingRowStyle CssClass="danger" />
                </asp:GridView>
            </div>
        </div>
        </div>
</asp:Content>
