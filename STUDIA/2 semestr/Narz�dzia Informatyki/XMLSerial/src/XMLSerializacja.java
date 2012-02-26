import java.beans.XMLDecoder;
import java.beans.XMLEncoder;
import java.io.BufferedInputStream;
import java.io.BufferedOutputStream;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;

public class XMLSerializacja {
	public static void main(String[] args) {
		Student a = new Student("Marcin", 1, 100, 43, 175, "male", "NW");
		try {
			XMLEncoder c = new XMLEncoder(new BufferedOutputStream(
					new FileOutputStream("studencik.xml")));
			c.writeObject(a);
			c.close();
		} catch (FileNotFoundException e) {
			e.printStackTrace();
		} catch (@SuppressWarnings("hiding") IOException e) {
			e.printStackTrace();
		}
		
		
		Object b = new Object();
		try {
			XMLDecoder d = new XMLDecoder(new BufferedInputStream(
					new FileInputStream("studencik.xml")));
			b = d.readObject();
			d.close();
		} catch (FileNotFoundException e) {
			e.printStackTrace();
		} catch (@SuppressWarnings("hiding") IOException e) {
			e.printStackTrace();
		}
		System.out.println(b);
	}
}
