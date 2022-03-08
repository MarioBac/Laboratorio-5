namespace Ejercicio5
{
    public partial class Form1 : Form
    {
        List<Empleado> empleados = new List<Empleado>();
        List<Asistencia> asistencias = new List<Asistencia>();
        List<Sueldos> sueldos = new List<Sueldos>();
        public Form1()
        {
            InitializeComponent();
        }

        private void CargarEmpleado()
        {
            FileStream stream = new FileStream("Empleados.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                Empleado empleado = new Empleado();
                empleado.NoEmpleado = Convert.ToInt16(reader.ReadLine());
                empleado.Nombre = reader.ReadLine();
                empleado.SueldoHora = Convert.ToDecimal(reader.ReadLine());


                empleados.Add(empleado);
            }
            reader.Close();
        }
        private void CargarAsistencia()
        {
            FileStream stream = new FileStream("Asistencia.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                Asistencia asistencia = new Asistencia();
                asistencia.NoEmpleado = Convert.ToInt16(reader.ReadLine());
                asistencia.HorasMes = Convert.ToInt16(reader.ReadLine());
                asistencia.Mes = reader.ReadLine();


                asistencias.Add(asistencia);
            }
            reader.Close();
        }
        private void CargarGrids()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.DataSource = empleados;

            dataGridView2.DataSource = null;
            dataGridView2.Refresh();
            dataGridView2.DataSource = asistencias;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            CargarEmpleado();
            CargarAsistencia();
            CargarGrids();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < empleados.Count; i++)
            {
                for(int j = 0;j < asistencias.Count; j++)
                    {
                    if (empleados[i].NoEmpleado == asistencias[j].NoEmpleado)
                    {
                        Sueldos sueldo = new Sueldos();
                        sueldo.NoEmpleado = empleados[i].NoEmpleado;
                        sueldo.Nombre = empleados[i].Nombre;
                        sueldo.SueldoMes = empleados[i].SueldoHora * asistencias[j].HorasMes;

                        sueldos.Add(sueldo);

                        
                    }
                    }
            }
            dataGridView3.DataSource = sueldos;
            dataGridView3.Refresh();
        }
    }
 
}