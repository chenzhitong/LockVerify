# NEO lock contract verify

## How to use

If you want to send an asset to the other on the Neo blockchain and ask the other person to be unable to use the asset for a specified period of time.

How do we do that?

**Receiver:**

You need to create an lock account via [neo-gui](https://neo.org/download), then send Redeem Script and Address to sender.

1. Open neo-gui and create/open your wallet.

2. Right-click in a blank place, `Create Contract Add.` `Lock...`

   ![](Images/2018-02-27_14-08-43.png)

3. Select your Account and Unlock Date, then click `Create`.

   ![](Images/2018-02-27_14-08-56.png)

4. Now you can see a Contract Address in your wallet. Righ click this Address, `View Contract`，and copy Redeem Script and Address to sender.

   ![](Images/2018-02-27_14-10-08.png)



**Sender:**

1. Open http://lockverify.azurewebsites.net/ and paste Redeem Script in textbox.

2. Click `Verify`

   ![](Images/2018-02-27_14-29-29.png)

3. If the Redeem Script is **not** correct lock contract, it will be alert error.

4. If the Redeem Script is correct lock contract, you can see Unlock date and Address.

5. Compare this address to the address which sender gave you.


