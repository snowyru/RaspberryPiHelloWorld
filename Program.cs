// See https://aka.ms/new-console-template for more information
//Link to docs :
//https://learn.microsoft.com/en-us/dotnet/iot/tutorials/blink-led
//to get the gpio package use dotnet add
using System;
using System.Device.Gpio;
using System.Threading;

Console.WriteLine("Welcome to Blinking LED."); 
int pin = 18;
using var controller = new GpioController(); //using key instance is disposed when program exits
controller.OpenPin(pin, PinMode.Output);
bool ledOn = true;

while (true)
{
    Console.WriteLine("Enter 1 for blink mode or 2 for toggle mode:");
    string input = Console.ReadLine()!;

    if (input.Trim() == "1")  // Blink mode
    {
        while (true)
        {
            controller.Write(pin, ((ledOn) ? PinValue.High : PinValue.Low));
            Thread.Sleep(1000);
            ledOn = !ledOn;
        }
    }
    else if (input.Trim() == "2")  // Toggle mode
    {
        while (true)
        {
            Console.WriteLine("Press Enter to toggle the LED or type '1' to choose mode again");
            string toggleInput = Console.ReadLine()!;
            if (toggleInput.ToLower().Trim() == "1")
            {
                break;
            }
            ledOn = !ledOn;
            controller.Write(pin, ((ledOn) ? PinValue.High : PinValue.Low));
        }
    }
    else
    {
        Console.WriteLine("Invalid input. Please enter 1 for blink mode or 2 for toggle mode.");
    }
}
