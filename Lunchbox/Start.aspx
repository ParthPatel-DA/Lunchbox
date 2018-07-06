<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Start.aspx.cs" Inherits="PayUDemo.Start" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Start Page</title>
    <style>
        #payu-payment-form button[type=submit] {
            border: 0px;
            height: 35px;
            width: 140px;
            background: url('http://static.payu.com/pl/standard/partners/buttons/payu_account_button_long_03.png');
            background-repeat: no-repeat;
            cursor: pointer;
        }
    </style>
</head>
<body>
    <div>
        <form method="post" id="payu-payment-form" action="//https://test.payu.in/_payment">
            <input type="hidden" name="customerIp" value="127.0.0.1" />
            <input type="hidden" name="merchantPosId" value="145227" />
            <input type="hidden" name="description" value="Order description" />
            <input type="hidden" name="currencyCode" value="PLN" />
            <input type="hidden" name="totalAmount" value="1000" />
            <input type="hidden" name="products[0].name" value="Product 1" />
            <input type="hidden" name="products[0].unitPrice" value="1000" />
            <input type="hidden" name="products[0].quantity" value="1" />
            <input type="hidden" name="continueUrl" value="http://localhost:4197/Continue.aspx" />
            <input type="hidden" name="OpenPayu-Signature" value="sender=145227;algorithm=MD5;signature=34267d8d3844d90af7a4aac24f8ee5e4" />
            <button type="submit" formtarget="_blank" value="Submit" />

        </form>
    </div>
</body>
</html>
