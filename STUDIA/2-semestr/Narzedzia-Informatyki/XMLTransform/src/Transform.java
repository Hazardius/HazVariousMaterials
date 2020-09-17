import java.io.File;
import javax.xml.transform.Source;
import javax.xml.transform.Transformer;
import javax.xml.transform.TransformerFactory;
import javax.xml.transform.stream.StreamResult;
import javax.xml.transform.stream.StreamSource;

public class Transform {

    /**
     * Performs an XSLT transformation, sending the results
     * to System.out.
     */
    public static void main(String[] args) throws Exception {
        File xmlFile = new File("book.xml");
        File xsltFile = new File("book.xsl");

        // JAXP reads data using the Source interface
        Source xmlSource = new StreamSource(xmlFile);
        Source xsltSource = new StreamSource(xsltFile);

        // the factory pattern supports different XSLT processors
        TransformerFactory transFact =
                TransformerFactory.newInstance();
        Transformer trans = transFact.newTransformer(xsltSource);

        trans.transform(xmlSource, new StreamResult("exit.xml"));
        trans.transform(xmlSource, new StreamResult(System.out));
    }
}