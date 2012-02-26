import java.io.Serializable;

public class Student implements Serializable {
	private static final long serialVersionUID = 1L;
	public String imie, plec, kierunek;
	public int rok_ur, dist, boot, high;

	private boolean deceased;

	public Student() {
	}

	public Student(String im, int rok, int dst, int bt, int hi, String sex,
			String kier) {
		imie = im;
		rok_ur = rok;
		dist = dst;
		boot = bt;
		high = hi;
		plec = sex;
		kierunek = kier;
	}

	public String toString() {
		return (imie + " " + rok_ur + "r. " + dist + "km " + kierunek + " "
				+ boot + " " + high + "cm " + plec);
	}

	public boolean isDeceased() {
		return this.deceased;
	}

	public void setDeceased(final boolean deceased) {
		this.deceased = deceased;
	}

	public String getImie() {
		return imie;
	}

	public void setImie(String imie) {
		this.imie = imie;
	}

	public String getPlec() {
		return plec;
	}

	public void setPlec(String plec) {
		this.plec = plec;
	}

	public String getKierunek() {
		return kierunek;
	}

	public void setKierunek(String kierunek) {
		this.kierunek = kierunek;
	}

	public int getRok_ur() {
		return rok_ur;
	}

	public void setRok_ur(int rok_ur) {
		this.rok_ur = rok_ur;
	}

	public int getDist() {
		return dist;
	}

	public void setDist(int dist) {
		this.dist = dist;
	}

	public int getBoot() {
		return boot;
	}

	public void setBoot(int boot) {
		this.boot = boot;
	}

	public int getHigh() {
		return high;
	}

	public void setHigh(int high) {
		this.high = high;
	}
}