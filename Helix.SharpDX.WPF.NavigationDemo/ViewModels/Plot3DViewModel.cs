using System;
using System.Windows.Media.Media3D;

using CommunityToolkit.Mvvm.ComponentModel;

using SharpDX;
using HelixToolkit.SharpDX.Core;
using HelixToolkit.Wpf.SharpDX;

using Camera = HelixToolkit.Wpf.SharpDX.Camera;
using PerspectiveCamera = HelixToolkit.Wpf.SharpDX.PerspectiveCamera;
using MeshGeometry3D = HelixToolkit.SharpDX.Core.MeshGeometry3D;
using System.Runtime.Intrinsics.X86;

namespace Helix.SharpDX.WPF.NavigationDemo.ViewModels;

public partial class Plot3DViewModel : ObservableObject, IDisposable
{
    public Plot3DViewModel()
    {
        System.Diagnostics.Trace.WriteLine("==== [Plot3DViewModel] Constructor ====");

        _effectsManager = new DefaultEffectsManager();

        _camera = new PerspectiveCamera
        {
            Position = new Point3D(5, 3, 8),
            LookDirection = new Vector3D(-3, -3, -5),
            UpDirection = new Vector3D(0, 1, 0),
        };

        _upDirection = new Vector3D(0, 1, 0);

        // Model
        var mb = new MeshBuilder();
        mb.AddBox(new Vector3(0, 0, 0), 2.0, 1.0, 1.0, BoxFaces.All);
        Model = mb.ToMeshGeometry3D();

        ModelTransform = new TranslateTransform3D(0, 0, 0);
        ModelMaterial = PhongMaterials.Red;
    }

    ~Plot3DViewModel()
    {
        System.Diagnostics.Trace.WriteLine("==== [Plot3DViewModel] Finalizer ====");

        Dispose(false);
    }

    #region Properties

    [ObservableProperty]
    private IEffectsManager? _effectsManager;

    [ObservableProperty]
    private Camera? _camera;

    [ObservableProperty]
    private Vector3D _upDirection;

    // Model
    public MeshGeometry3D? Model { get; private set; }
    public Transform3D ModelTransform { get; private set; }
    public PhongMaterial ModelMaterial { get; private set; }

    #endregion

    #region IDisposable implementation

    // Free unmanaged DirectX resources, 
    // <see href="https://learn.microsoft.com/en-us/dotnet/api/system.idisposable">IDisposible</see>
    // description for details.

    private bool disposed = false;

    public void Dispose()
    {
        System.Diagnostics.Trace.WriteLine("==== [Plot3DViewModel] Dispose ====");

        Dispose(true);
        //GC.SuppressFinalize(this);
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            // Dispose all managed resources
            if (disposing)
            {

            }

            // Cleanup all unmanaged resources
            if (_effectsManager != null)
            {
                Disposer.RemoveAndDispose(ref _effectsManager);
            }

            disposed = true;
        }
    }

    #endregion
}
