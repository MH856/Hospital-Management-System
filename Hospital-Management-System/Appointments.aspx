<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Appointments.aspx.cs" Inherits="ICT365_Assignment2.Appointments" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container">
        <div class="row">
            <div class="col-md-4 "></div>
            <div class="col">
                <h1 class="text-danger">Manage Appointments</h1>
            </div>
        </div>
        <div class="row">

            <div class="col-md-4">
                <div>
                    <h2 class="text-danger">Appointments Details</h2>
                </div>
                <div>

                </div>

                <div>
                    <form>
                        <div class="mb-3">
                            <label for="exampleInputEmail1" class="form-label">Patient</label>
                            <asp:DropDownList ID="PatientDDL" class="form-control" runat="server">

                            </asp:DropDownList>
                        </div>
                        <br />
                        <div class="mb-3">
                            <label for="exampleInputEmail1" class="form-label">Treatment</label>
                            <asp:DropDownList ID="TreatmentDDL" class="form-control" runat="server">

                            </asp:DropDownList>
                        </div>
                        <br />
                        <div class="mb-3">
                            <label for="exampleInputEmail1" class="form-label">Appointment Date</label>
                            <input type="date" class="form-control" id="ApDate" runat="server">
                        </div>
                        <br />
                        <div class="mb-3">
                            <label for="exampleInputEmail1" class="form-label">Appointment Time</label>
                            <asp:DropDownList ID="ApTime" class="form-control" runat="server">
                                <asp:ListItem>8AM-10AM</asp:ListItem>
                                <asp:ListItem>3PM-5PM</asp:ListItem>
                                <asp:ListItem>8PM-10PM</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <br />
                        <asp:Button ID="ApEditBtn" runat="server" Text="Edit" class="btn btn-danger" OnClick="ApEditBtn_Click" />
                        <asp:Button ID="ApAddBtn" runat="server" Text="Save" class="btn btn-danger" OnClick="ApAddBtn_Click" />                        
                        <asp:Button ID="ApDeleteBtn" runat="server" Text="Delete" class="btn btn-danger" OnClick="ApDeleteBtn_Click" />
                    </form>
                </div>
                <div>

                </div>
            </div>
            <div class="col-md-8">
                <div>
                    <h2 class="text-primary">Appointments List</h2>
                </div>
                <asp:GridView ID="AppointmentGV" runat="server" CssClass="table table-condensed table-bordered table-hover" AutoGenerateSelectButton="true" BorderStyle="None" OnSelectedIndexChanged="AppointmentGV_SelectedIndexChanged">
                    <AlternatingRowStyle CssClass="danger" />
                </asp:GridView>
            </div>
        </div>
        </div>
</asp:Content>