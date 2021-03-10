# ATcommand
A small Windows utility for testing AT-commands.

![Screendump](/doc/screen.png)

The program was used when testing an ESP-01 with AT Firware before implementing it with a Raspberry Pico to give it Internet access.

Thanks to Adafruit for code to fetch current Bitcoin price as a small demo.

The code is NOT finished - currently not handling the text entered into the "Get Web-page" textbox, but the code behind the "bitcoin test" button is an indication of what to be done.

The main task in this operation is to have a handshake between the UART-write and the response which is a separate task.
The plan is to have a sort of "token" generated on transmitt that is then tested for an "OK" or "ERROR" response in the receiving part of the code.

## Short description:
Before using the WiFi settings (SSID and password) you need to use the "Select AT Command" to set "WiFi mode Client".

Then hit the CWJAP-button.

The "Lookup Host" is ment for getting a host IP, enter for instance www.cisco.com followed by a CR and an IP-address should show in the textbox on the right. The IP address will also be put into the "Ping Host" textbox. Just move the cursor to the field and hit CR and the result should be dislayed.
