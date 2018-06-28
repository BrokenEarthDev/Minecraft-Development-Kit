package me.brokenearth.extractor;

import java.io.*;

public final class Extractor {

    public static void extract() throws IOException{
        File mcp = new File("mcp");
        File mod = new File("forge");
        File proxy = new File("proxy");
        File server = new File("server");
        File mcpe = new File("mcpe");
        copyFolder(mcp, new File("../mcps"));
        copyFolder(mod, new File("../forge"));
        copyFolder(proxy, new File("../proxies"));
        copyFolder(server, new File("../servers"));
        copyFolder(mcpe, new File("../mcpe"));
    }

    public static void extract(File file, File destination) throws IOException {
           copyFolder(file, destination);
    }

    private static void copyFolder(File src, File dest) throws IOException {
        if(src.isDirectory()){
            if(!dest.exists()){
                dest.mkdir();
            }
            String files[] = src.list();
            for (String file : files) {
                File srcFile = new File(src, file);
                File destFile = new File(dest, file);
                copyFolder(srcFile,destFile);
            }

        }else{
            InputStream in = new FileInputStream(src);
            OutputStream out = new FileOutputStream(dest);

            byte[] buffer = new byte[1024];

            int length;
            while ((length = in.read(buffer)) > 0){
                out.write(buffer, 0, length);
            }
            in.close();
            out.close();
        }
    }
}