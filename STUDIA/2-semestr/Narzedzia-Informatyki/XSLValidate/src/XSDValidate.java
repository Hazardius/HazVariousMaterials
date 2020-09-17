import javax.xml.transform.stream.StreamSource;
import javax.xml.validation.Schema;
import javax.xml.validation.SchemaFactory;
import javax.xml.validation.Validator;

public class XSDValidate {
	public static void main(String[] args) {
		try {
			SchemaFactory factory = SchemaFactory
					.newInstance("http://www.w3.org/2001/XMLSchema");

			Schema schema = factory.newSchema(new StreamSource(
					"J:/My Documents/NIF/XML/students.xsd"));
			Validator validator = schema.newValidator();

			// at last perform validation:
			validator.validate(new StreamSource(
					"J:/My Documents/NIF/XML/students.xml"));

			System.out.println("Pliki sa poprawne!");
			
		} catch (Exception ex) {
			System.out.println("Pliki sa niepoprawne!");
			ex.printStackTrace();
		} 
	}
}