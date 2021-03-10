# ATcommand
A small Windows utility for testing AT-commands.

The program was used when testing an ESP-01 with AT Firware before implementing it with a Raspberry Pico to give it Internet access.

Thanks to Adafruit for code to fetch current Bitcoin price as a small demo.

The code is NOT finished - currently not handling the text entered into the "Get Web-page" textbox, but the code behind the "bitcoin test" button is an indication of what to be done.

The main task in this operation is to have a handshake between the UART-write and the response which is a separate task.
The plan is to have a sort of "token" generated on transmitt that is then tested for an "OK" or "ERROR" response in the receiving part of the code.
