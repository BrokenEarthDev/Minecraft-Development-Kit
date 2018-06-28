package me.brokenearth;

import me.brokenearth.extractor.Extractor;

import java.io.IOException;
import java.util.Scanner;

public final class Main {

    public static void main(String[] args) {
        System.out.println("Minecraft Development Kit [MDK] for 1.8.9...");
        System.out.print("Press enter to continue... ");
        new Scanner(System.in).nextLine();
        try {
            Extractor.extract();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
