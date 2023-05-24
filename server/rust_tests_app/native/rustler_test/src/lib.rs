#[allow(dead_code, unused)]
#[deny(unused_must_use)]
pub mod game_state_test;
pub mod utils;
rustler::init!(
    "Elixir.TestNIFs",
    [
        game_state_test::no_move_if_beyond_boundaries,
        game_state_test::no_move_if_occupied,
        game_state_test::attacking,
        // game_state_test::no_move_if_wall,
        game_state_test::movement
    ],
    load = gamestate::load
);