//Para obtener los componentes de un formulario por reflection
public ComponentCollection GetComponents(Form frm)
{
	List<Component> components = new List<Component>();
	FieldInfo[] fieldInfos = frm.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
	foreach (FieldInfo f in fieldInfos)
	{
		if (f.FieldType.BaseType == typeof(Component))
		{
			Component c = f.GetValue(frm) as Component;
			if (c != null)
				components.Add(c);
		}
	}

	//foreach (var item in collection)
	//{
		
	//}

	ComponentCollection ArrayComponentes = new ComponentCollection(components.ToArray());

	return ArrayComponentes;
}



//Para traducir los componentes (que no funcionó)
//Traducir msjs de error de las validaciones
	foreach (Component item in unosComponentes)
	{
		if (item.GetType() == typeof(ErrorProvider) && (item as ErrorProvider).Tag != null)
		{
			MessageBox.Show(item.GetType().Name);
			string unaClave = ((item as ErrorProvider).Tag as Dictionary<string, string[]>)["Idioma"].First();
			foreach (Etiqueta unaEtiqueta in Idioma._EtiquetasCompartidas)
			{
				if (string.Equals(unaClave, unaEtiqueta.NombreControl))
				{
					(item as ErrorProvider).SetError(item.Container as Control, unaEtiqueta.Texto);
					break;
				}
			}
		}

	}