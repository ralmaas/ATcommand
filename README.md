# ATcommand
A small Windows utility for testing AT-commands.

![Screendump](/doc/screen_1.2.png)

The program was used when testing an ESP-01 with AT Firware before implementing it with a Raspberry Pico to give it Internet access.

Thanks to Adafruit for code to fetch current Bitcoin price as a small demo.

The AT-version installed on the ESP-01 is:

>AT version:1.7.4.0(May 11 2020 19:13:04)
>SDK version:3.0.4(9532ceb)
>compile time:May 27 2020 10:12:17
>Bin version(Wroom 02):1.7.4

## Short description:
The "Lookup Host" is ment for getting a host IP, enter for instance www.cisco.com followed by a CR and an IP-address should show in the textbox on the right. 
The IP address will also be put into the "Ping Host" textbox. Just move the cursor to the field and hit CR and the result should be dislayed.

## Version 1.2
Bitcoin demo-code is now operational!
Decoding of json-data done using the Netwtonsoft.Json package.
![Screendump](/doc/bitcoin.png)
## Version 1.3
The textbox "Get Web-page" is now operative!

PS: The textbox to the left of the Clear-button is used for debug-messages.