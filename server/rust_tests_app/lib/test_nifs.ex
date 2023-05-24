defmodule TestNIFs do
  use Rustler, otp_app: :rust_tests, crate: "rustler_test", default_features: false
  def err(), do: :erlang.nif_error(:nif_not_loaded)
  def no_move_if_beyond_boundaries(), do: err()
  def no_move_if_occupied(), do: err()
  def attacking(), do: err()
  # def no_move_if_wall(), do: err()
  def movement(), do: err()
end