namespace Assets.Code
{
    internal class UI
    {
        Player _player;
        UnityEngine.UI.Text _hp_text;
        internal void initialize(Player player)
        {
            _player = player;
            UnityEngine.GameObject prefab = UnityEngine.Resources.Load<UnityEngine.GameObject>("hp_ui");
            UnityEngine.GameObject instance = UnityEngine.Object.Instantiate(prefab, SampleScene.Canvas.transform);
            _hp_text = instance.GetComponent<UnityEngine.UI.Text>();
        }

        internal void process()
        {
            _hp_text.text = string.Format("Hp:{0}", _player.getHp());
        }
    }
}
